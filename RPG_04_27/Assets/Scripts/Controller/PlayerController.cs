using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged onFocusChanged;

    Camera cam;
    PlayerMoter moter;
    Rigidbody rigid;
    Animator anim;
    public LayerMask movementMask;
    public LayerMask interationMask;

    public Interactable focus;

    private void Awake()
    {
        cam = Camera.main;
        moter = GetComponent<PlayerMoter>();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                DeFocus();
                moter.MoveToTarget(hit.point);
            }
        }
        rigid.velocity = Vector3.zero;


        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interationMask))
            {
                SetFocus(hit.collider.GetComponent<Interactable>());
            }
        }

        //if (!agent.pathPending)
        //{
        //    if (agent.remainingDistance <= agent.stoppingDistance)
        //    {
        //        anim.SetFloat("Walk", 0.0f);
        //    }
        //}
        //anim.SetFloat("Walk", );

        void SetFocus(Interactable newFocus)
        {
            //if (onFocusChanged != null)
            //{
            //    onFocusChanged(newFocus);
            //}
            onFocusChanged?.Invoke(newFocus);
        }

        void DeFocus()
        {
            focus = null;
        }
    }
}
