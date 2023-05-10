using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public event Action OnIdle;
    public event Action OnAttack;
    public event Action OnHitted;
    public event Action OnDie;

    #region COOLTIME
    const float cooltime = 1f;
    public float attackCooltime = 0f;
    //public float attackSpeed = 1f;
    //public float attackDelay = 1f;
    float lastAttackTime;
    public bool isInCombat = false;
    #endregion

    CharacterStat myStat;

    private void Awake()
    {
        myStat = GetComponent<CharacterStat>();
    }

    public void Attack(CharacterStat enemyStat)
    {        
        if (attackCooltime <= 0f)
        {
            enemyStat.Hitted(myStat.power);
            enemyStat.GetComponent<CharacterCombat>().Hitted();

            if (OnAttack != null)
            {
                OnAttack();                
            }
            isInCombat = true;
            attackCooltime = cooltime;
            lastAttackTime = Time.time;
        }
    }

    public void Hitted()
    {
        OnHitted?.Invoke();
    }

    private void Update()
    {
        attackCooltime -= Time.deltaTime;

        if (Time.time - lastAttackTime > cooltime)
        {
            isInCombat = false;
        }
    }
}
