using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject hero;
    private GameObject enemy;

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
    }
    public void SelectAttack(string btn)
    {
        GameObject victim = hero;
        if (tag == "Hero")
        {
            victim = enemy;
        }
        if (btn.CompareTo("sword") == 0)
        {
            swordPrefab.GetComponent<AttackScript>().Attack(victim);

        }
        else if (btn.CompareTo("bow") == 0)
        {
            bowPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else
        {
            magicPrefab.GetComponent<AttackScript>().Attack(victim);
            Debug.Log("magic");
        }
    }
}
