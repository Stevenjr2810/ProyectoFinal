using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    private float ejeX;
    private float ejeY;
    private float ejeZ;
    private Vector3 posicionInicial;
    private Rigidbody rbDado;
    public FaceController[] lados = new FaceController[20];
    public int valorDado; // Hacerlo público para que sea accesible desde DiceManager
    private int ladoOculto;
    public bool dadoEnMovimiento = true; // Hacerlo público para que sea accesible desde DiceManager

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = this.transform.position;
        rbDado = this.GetComponent<Rigidbody>();
        PrepararDado();
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PrepararDado();
        }

        if (rbDado.IsSleeping() && dadoEnMovimiento)
        {
            dadoEnMovimiento = false;
            ladoOculto = ComprobarLados();
            valorDado = 21 - ladoOculto;
            if (valorDado == 21)
            {
                rbDado.AddForce(3f, 0, 0, ForceMode.Impulse);
                dadoEnMovimiento = true;
            }
        }
        if (!dadoEnMovimiento)
        {
            UIControl.instancia.ActualizarValor(valorDado);
        }
    }
    // Método público para ser llamado desde DiceManager
    public void RollDice()
    {
        PrepararDado();
    }

    public void PrepararDado()
    {
        this.transform.position = posicionInicial;
        rbDado.velocity = new Vector3(0f, 0f, 0f);
        UIControl.instancia.LimpiarValores();
        dadoEnMovimiento = true;
        ejeX = Random.Range(0f, 271f);
        ejeY = Random.Range(0f, 271f);
        ejeZ = Random.Range(0f, 271f);
        this.transform.Rotate(ejeX, ejeY, ejeZ);
        ejeX = Random.Range(-3f, 3f);
        ejeY = Random.Range(-2f, 0f);
        ejeZ = Random.Range(-3f, 3f);
        rbDado.AddForce(ejeX, ejeY, ejeZ, ForceMode.Impulse);
    }

    int ComprobarLados()
    {
        int valor = 0;
        for (int i = 0; i < 20; i++)
        {
            if (lados[i].CompruebaSuelo())
            {
                valor = i + 1;
            }
        }

        return valor;
    }
}