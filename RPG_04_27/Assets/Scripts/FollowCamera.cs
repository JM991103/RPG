using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    private void Start()
    {
        offset = player.position - transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position - offset, Time.deltaTime);
    }
}
