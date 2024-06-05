using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public static UIControl instancia;
    [SerializeField] private TMP_Text Dado;
    private int valorD1 = 0;

    private void OnEnable()
    {

        if (instancia == null)
        {
            instancia = this;
        }
    }

    public void ActualizarValor(int dado)
    {

        if (valorD1 == 0)
        {
            valorD1 = dado;
        }
        else
        {
            Dado.text = "Dado : " + valorD1.ToString();
        }
        //if (valorD1 != 0)
        //{
        //    dado.text = "Dado : " + valorD1.ToString();
        //}
    }

    public void LimpiarValores()
    {
        valorD1 = 0;
        Dado.text = "Dado : " + valorD1.ToString();

    }
}
