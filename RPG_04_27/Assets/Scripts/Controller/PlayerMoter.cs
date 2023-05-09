using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static PlayerController;

public class PlayerMoter : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;

    private void OnEnable()
    {
        GetComponent<PlayerController>().onFocusChanged += OnFocusChanged;
    }

    private void OnDisable()
    {
        GetComponent<PlayerController>().onFocusChanged -= OnFocusChanged;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToTarget(Vector3 position)
    {
        agent.SetDestination(position);
    }

    void OnFocusChanged(Interactable newFocus)
    {
        if(newFocus != null)
        {
            target = newFocus.guideTransform;
            agent.updateRotation = false;
            agent.stoppingDistance = newFocus.size;
        }
        else
        {
            target = null;
            agent.updateRotation = true;
            agent.stoppingDistance = 0;
        }
    }
}
