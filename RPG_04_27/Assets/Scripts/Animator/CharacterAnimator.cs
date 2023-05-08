using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    // 캐릭터들의 애니메이터 파아미터를 조절하는 부분
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
        combat.OnAttack += OnAttack;
        combat.OnHitted += OnHitted;
        combat.OnDie += OnDie;
    }

    private void Update()
    {
        animator.SetFloat("Walk", agent.velocity.magnitude);
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
        combat.OnAttack -= OnAttack;
        combat.OnHitted -= OnHitted;
        combat.OnDie -= OnDie;
    }
}
