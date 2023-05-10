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
    CharacterCombat combat;
    public LayerMask movementMask;
    public LayerMask interationMask;

    public Interactable focus;

    private void Awake()
    {
        cam = Camera.main;
        moter = GetComponent<PlayerMoter>();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        combat = GetComponent<CharacterCombat>();
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
                SetFocus(null);
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
                //combat.Attack();
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

            if (focus != newFocus && focus != null)
            {
                // 기존에 선택되었던 인터랙터블 객체에도 알려주어야 한다.
                focus.onDeFocused();
            }

            focus = newFocus;
            if (focus != null)
            {
                // 새로 선택된 인터랙터블 객체에 알려주자.
                focus.onFocused(transform);
            }
            
        }

        void DeFocus()
        {
            focus = null;
        }
    }
}
