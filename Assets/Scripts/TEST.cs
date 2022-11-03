using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TEST : MonoBehaviour
{
// ===========AI Variable===============
  [field: SerializeField] Transform target;
  [field: SerializeField] float chaseRange = 5f;
  [field: SerializeField] private EnemyWaves _waveManager;
  NavMeshAgent navMeshAgent;
  float distanceToTarget = Mathf.Infinity;
  bool isProvoked = false;
  [field: SerializeField]
  int damage = 5;
  [field: SerializeField]
  float coolDown { get; set; } = 1f;
  float CDTimer;
  // private float attackSpeed { get; set; } = 1f;
  
  // ==========Animation Variables===========

  Animator toDoAnimator;

  // ==========Target Variables==========
  public float health =10f;
  public void TakeDamage (float amount)
  {
    Debug.Log("Taking damage");
    health =- amount;
    if (health <= 0)
    {
        Die(); 
    }
  }

  void Die ()
  {
    Debug.Log(name + " has died due to being shot!");
    Destroy(gameObject);
    _waveManager.UpdateScore();
    _waveManager.enemiesLeft--;
  }
  // ====================================

    // Start is called before the first frame update
    void Start()
    {
      CDTimer = coolDown;
      target = GameObject.Find("Player").GetComponent<Transform>();
      navMeshAgent = GetComponent<NavMeshAgent>();
      _waveManager = GameObject.Find("WaveManager").GetComponent<EnemyWaves>();
      toDoAnimator = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
      distanceToTarget = Vector3.Distance(target.position, transform.position);
      ChaseTarget();
      EngageTarget();
      if(CDTimer < coolDown)
      {
        CDTimer += Time.deltaTime;
      }

    // // AI's Attack/Engage/(something else?)  Logic 
    //   if(distanceToTarget <= chaseRange)
    //   {
    //     isProvoked = true;
    //   }
    //   else if(distanceToTarget > chaseRange)
    //   {
    //     isProvoked = false;
    //   }

    //   if(!isProvoked)
    //   {
    //     navMeshAgent.SetDestination(transform.position);
    //     toDoAnimator.SetBool("IsWalking", false);
    //   }
    //   else
    //   {
    //     EngageTarget();
    //   }



      // if(isProvoked)
      // {
      //   EngageTarget();
      //   if(distanceToTarget >= chaseRange)
      //   {
      //     isProvoked = false;
      //     chaseRange = 20f;
      //     navMeshAgent.SetDestination(transform.position);
      //     toDoAnimator.SetBool("IsWalking", false);
      //   }
      // }
      // else if(distanceToTarget <= chaseRange)
      // {
      //   Debug.Log("Hit else if");
      //   isProvoked = true;
      //   chaseRange = 35f;
      // }
      // else
      // {
      //   Debug.Log("Hit else");
        
      // }
    }

    void ChaseTarget()
    {
      navMeshAgent.SetDestination(target.position);
      toDoAnimator.SetBool("IsWalking", true);
    }

    void AttackTarget()
    {
      Player player = target.GetComponent<Player>();
      if(player != null)
      {
        player.TakeDamage(this.gameObject, damage);
        CDTimer = 0;
      }
    }

    void EngageTarget()
    {
      if(distanceToTarget > navMeshAgent.stoppingDistance && distanceToTarget <=  chaseRange)
      {
        
      }

      if(distanceToTarget <= navMeshAgent.stoppingDistance && CDTimer >= coolDown)
      {
        AttackTarget();
      }
    }

    void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
