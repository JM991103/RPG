using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public enum State { Move, Attack, Hit }
    public State state = State.Move;
    public int hp = 100;

    NavMeshAgent agent;
    Animator anim;
    public LayerMask movementMask;

    public int walkID = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Enemy")
        {
            state = State.Attack;
            anim.SetTrigger("Attack");
        }

        if (state != State.Hit)
        {
            state = State.Hit;
            hp -= 10;
            Debug.Log($"{hp}");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        state = State.Move;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            agent.isStopped = false;
            anim.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            agent.isStopped = true;
            anim.SetTrigger("Hit");
        }
        if (Input.GetMouseButtonDown(1))
        {
            agent.isStopped = false;
            anim.SetTrigger("Die");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                agent.isStopped = false;
                agent.SetDestination(hit.point);
            }
        }

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.isStopped = true;
                anim.SetFloat("Walk", 0.0f);
            }
        }

        anim.SetFloat("Walk", agent.velocity.sqrMagnitude);
    }
}
