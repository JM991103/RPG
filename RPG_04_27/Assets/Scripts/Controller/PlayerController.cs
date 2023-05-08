using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    PlayerMoter moter;
    Rigidbody rigid;
    public LayerMask movementMask;

    private void Awake()
    {
        cam = Camera.main;
        moter = GetComponent<PlayerMoter>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {                
                moter.MoveToTarget(hit.point);
            }
        }
        rigid.velocity = Vector3.zero;
    }
}
