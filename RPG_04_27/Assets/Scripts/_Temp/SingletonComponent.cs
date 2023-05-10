using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonComponent : MonoBehaviour
{
    private static SingletonComponent instance;

    public static SingletonComponent Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<SingletonComponent>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<SingletonComponent>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }
}
