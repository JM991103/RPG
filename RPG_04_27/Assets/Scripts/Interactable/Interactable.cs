using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float size;
    public Transform guideTransform;
    public Transform playerTransform;

    bool isFocus = false;
    bool isInteracted = false;


    public virtual void Interact()
    {

    }

    private void Update()
    {
        if (isFocus)
        {

            float distance = Vector3.Distance(guideTransform.position, playerTransform.position);

            //float magnitude = (transform.position - playerTransform.position).magnitude;

            //Debug.LogFormat("{0} / {1} == {2}", (distance == magnitude), distance, magnitude);

            //float sqrmagnitude = (transform.position - playerTransform.position).sqrMagnitude;

            if (distance < size)
            {
                isInteracted = true;
                Interact();
            }
        }                
    }

    public void onFocused(Transform tf)
    {
        isFocus = true;
        playerTransform = tf;
        isInteracted = false;
    }

    public void onDeFocused()
    {
        isFocus = false;
        playerTransform = null;        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(guideTransform.position, size);
    }
}
