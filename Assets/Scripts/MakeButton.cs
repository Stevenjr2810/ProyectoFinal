
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField]
    private bool physical;

    private GameObject hero;
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    private void AttachCallback(string btn)
    {
        if (btn.CompareTo("Espada") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("sword");
        }
        else if (btn.CompareTo("Arco") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("bow");
        }
        else
        {
            hero.GetComponent<FighterAction>().SelectAttack("magia");
        }
    }
}