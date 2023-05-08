using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class delegateTest2 : MonoBehaviour
{
    [SerializeField]
    delegateTest test;

    //public delegateTest dt;
    int item = 0;

    int Additem(int val)
    {
        item += val;
        Debug.Log($"item => {item}");
        return item;
    }

    private void Awake()
    {
        test = FindObjectOfType<delegateTest>();
    }

    void Attack(int n)
    {
        Debug.Log($"{n}만큼 공격을 받았습니다.");
    }

    private void Start()
    {
        //dt.characterInfo += new delegateTest.CharacterInfo(Additem);
        //dt.characterInfo += Additem;
        //dt.characterInfo(200);

        //delegateTest.characterInfoHandler += Additem;

        test.CharacterInfo3 += Attack;

        test.CharacterInfo4 += Additem;
    }
}
