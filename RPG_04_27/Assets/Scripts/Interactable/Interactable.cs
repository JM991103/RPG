using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float size;
    public Transform guideTransform;
    public Transform playerTransform;

    private void Update()
    {        
        float distance = Vector3.Distance(guideTransform.position, playerTransform.position);

        //float magnitude = (transform.position - playerTransform.position).magnitude;

        //Debug.LogFormat("{0} / {1} == {2}", (distance == magnitude), distance, magnitude);

        //float sqrmagnitude = (transform.position - playerTransform.position).sqrMagnitude;
                
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(guideTransform.position, size);
    }
}
