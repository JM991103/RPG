using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    // ĳ���͵��� �ִϸ����� �ľƹ��͸� �����ϴ� �κ�
    CharacterCombat combat;
    Animator animator;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();
    }

    private void OnEnable()
    {
        combat.OnIdle += OnIdle;
        combat.OnAttack += OnAttack;
        combat.OnHitted += OnHitted;
        combat.OnDie += OnDie;                
    }

    private void Update()
    {
        animator.SetFloat("Walk", agent.velocity.magnitude);
    }

    void OnIdle()
    {
        animator.SetFloat("Walk", 0f);
    }

    void OnAttack()
    {
        animator.SetTrigger("Attack");
    }

    void OnHitted()
    {
        animator.SetTrigger("Hit");
    }

    void OnDie()
    {
        animator.SetTrigger("Die");
    }

    private void OnDisable()
    {
        combat.OnIdle -= OnIdle;
        combat.OnAttack -= OnAttack;
        combat.OnHitted -= OnHitted;
        combat.OnDie -= OnDie;
    }
}
