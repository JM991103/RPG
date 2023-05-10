using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    CharacterCombat combat;
    public Transform target;

    public float detectionSize;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    private void Update()
    {
        float distance = (target.position - transform.position).magnitude;

        if (distance < detectionSize)
        {
            agent.SetDestination(target.position);
            if (distance < agent.stoppingDistance)
            {
                
                combat.Attack(Player.instance.Stat);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionSize);
    }
}
