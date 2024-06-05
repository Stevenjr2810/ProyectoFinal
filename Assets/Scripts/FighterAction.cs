using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAction : MonoBehaviour
{
    private GameObject hero;
    private GameObject enemy;
    private Animator heroAnimator;
    private Animator enemyAnimator;

    [SerializeField]
    private GameObject swordPrefab;

    [SerializeField]
    private GameObject bowPrefab;

    [SerializeField]
    private GameObject magicPrefab;

    [SerializeField]
    private Sprite faceIcon;

    private GameObject currentAttack;

    void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (hero != null)
        {
            heroAnimator = hero.GetComponent<Animator>();
        }

        if (enemy != null)
        {
            enemyAnimator = enemy.GetComponent<Animator>();
        }
    }

    public void SelectAttack(string btn)
    {
        GameObject victim = hero;
        Animator attackerAnimator = heroAnimator;
        if (tag == "Hero")
        {
            victim = enemy;
            attackerAnimator = enemyAnimator;
        }

        if (btn.CompareTo("sword") == 0)
        {
            swordPrefab.GetComponent<AttackScript>().Attack(victim);
            StartCoroutine(PlayAttackAnimation(attackerAnimator, "SwordAttack"));
        }
        else if (btn.CompareTo("bow") == 0)
        {
            bowPrefab.GetComponent<AttackScript>().Attack(victim);
            StartCoroutine(PlayAttackAnimation(attackerAnimator, "BowAttack"));
        }
        else
        {
            magicPrefab.GetComponent<AttackScript>().Attack(victim);
            StartCoroutine(PlayAttackAnimation(attackerAnimator, "MagicAttack"));
            Debug.Log("magic");
        }
    }

    private IEnumerator PlayAttackAnimation(Animator animator, string triggerName)
    {
        animator.SetTrigger(triggerName);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetTrigger("Idle");
    }
}
