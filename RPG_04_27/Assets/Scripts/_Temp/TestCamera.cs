using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    [SerializeField]
    public Transform cameraArm;
    [SerializeField]
    public Transform PlayerBody;

    private void Update()
    {
        LookAround();
    }

    void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Debug.Log(mouseDelta.x);
        Debug.Log(mouseDelta.y);

        Vector3 camAngle = cameraArm.rotation.eulerAngles;

        cameraArm.rotation = Quaternion.Euler(camAngle.x = mouseDelta.y, camAngle.y + mouseDelta.x, camAngle.z);
    }
}
