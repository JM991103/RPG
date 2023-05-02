using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake");
        Debug.LogWarning("Awake");
        Debug.LogError("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    private void Start()
    {
        Debug.Log("Start");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void Update()
    {
        Debug.Log("Update");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }
}
