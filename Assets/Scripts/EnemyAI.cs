using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

  [SerializeField] Transform target;
  [SerializeField] float chaseRange = 5f;
  NavMeshAgent navMeshAgent;
  float distanceToTarget = Mathf.Infinity;
  bool isProvoked = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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

    void AttackTarget()
    {
      Debug.Log(name + " has attacked " + target.name);
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

