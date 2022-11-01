using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

// ===========AI Variable===============
  [SerializeField] Transform target;
  [SerializeField] float chaseRange = 5f;
  [field: SerializeField] private EnemyWaves _waveManager;
  NavMeshAgent navMeshAgent;
  float distanceToTarget = Mathf.Infinity;
  bool isProvoked = false;
  int damage = 1;
  private float attackSpeed { get; set; } = 1f;
  
  // ====================================

  // ==========Target Variables==========
  public float health = 50f;
  public void TakeDamage (float amount)
  {
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
  }
  // ====================================

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _waveManager = GameObject.Find("SpawnManager").GetComponent<EnemyWaves>();
    }

    // Update is called once per frame
    void Update()
    {
      distanceToTarget = Vector3.Distance(target.position, transform.position);

      if(isProvoked)
      {
        EngageTarget();
        if(distanceToTarget >= chaseRange)
        {
          isProvoked = false;
          chaseRange = 20f;
          navMeshAgent.SetDestination(transform.position);
        }
      }
      else if(distanceToTarget <= chaseRange)
      {
        isProvoked = true;
        chaseRange = 35f;
      }
    }

    void ChaseTarget()
    {
      navMeshAgent.SetDestination(target.position);
    }

    IEnumerator AttackLogic()
    {
      while(true)
      {
        AttackTarget();
        yield return new WaitForSeconds(attackSpeed);
      }
    }

    void AttackTarget()
    {
      Player player = target.GetComponent<Player>();
      if(player != null)
      {
        player.TakeDamage(this.gameObject, damage);
      }
    }

    void EngageTarget()
    {
      if(distanceToTarget >= navMeshAgent.stoppingDistance)
      {
        ChaseTarget();
      }

      if(distanceToTarget <= navMeshAgent.stoppingDistance)
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

