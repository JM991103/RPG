using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delegateTest : MonoBehaviour
{
    //public delegate int CharacterInfo(int val);

    //public static event CharacterInfo characterInfoHandler;

    //public CharacterInfo characterInfo;

    public Action<int> CharacterInfo3;
    public Func<int, int> CharacterInfo4;



    int hp;
    int defense;

    void Attack(int n)
    {
        Debug.Log($"{n}만큼 공격을 받았습니다.");
    }

    int AddHP(int n)
    {
        Debug.Log($"HP가 {n} 만큼 증가했습니다");
        return hp + n;
    }

    int AddDefense(int n)
    {
        Debug.Log($"defense가 {n} 만큼 증가했습니다");
        return defense + n;
    }

    //int ChangeCharacterData(int val, CharacterInfo characterInfo)
    //{
    //    int result = characterInfo(val);
    //    return result;
    //}

    private void Start()
    {
        //AddHP(10);
        //AddDefense(10);

        //characterInfo myCharacterInfo = new characterInfo(AddHP);
        //int temp = myCharacterInfo(5);
        //Debug.Log(temp);

        //myCharacterInfo = new characterInfo(AddDefense);
        //temp = myCharacterInfo(10);
        //Debug.Log(temp);

        //characterInfo = new CharacterInfo(AddDefense);
        //characterInfo += new CharacterInfo(AddHP);
        //characterInfo(20);

        //characterInfo -= new CharacterInfo(AddHP);
        //characterInfo(70);

        //characterInfo -= new CharacterInfo(AddDefense);
        //characterInfo(10);

        //characterInfoHandler += AddHP;        
        //characterInfoHandler(100);

        if (CharacterInfo3 != null)
        {
            CharacterInfo3(40);
        }
        if (CharacterInfo4 != null)
        {
            CharacterInfo4(50);
        }
    }
}
