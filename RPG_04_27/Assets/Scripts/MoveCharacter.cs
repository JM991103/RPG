using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public Transform tf;
    public Transform target;
    public float deltaMoving = 0.1f;

    private void Awake()
    {
        //tf = GetComponent<Transform>();
    }

    private void Update()
    {
        //tf.Translate(new Vector3(0f, 0f, deltaMoving) * Time.deltaTime);

        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Vector3 vecRaw = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        tf.Translate(vec);

        //tf.position = Vector3.MoveTowards(tf.position, target.position, 1.0f);

        //Vector3 velocity = Vector3.zero;
        //tf.position = Vector3.SmoothDamp(tf.position, target.position, ref velocity, 1f);

        // 보간
        //tf.position = Vector3.Lerp(tf.position, target.position, 0.5f);

        // 선형 보간
        //tf.position = Vector3.Slerp(tf.position, target.position, 0.1f);
    }
}
