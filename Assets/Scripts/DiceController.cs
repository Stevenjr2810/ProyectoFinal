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

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = this.transform.position;
        rbDado = this.GetComponent<Rigidbody>();
        PrepararDado();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PrepararDado();
        }
    }

    void PrepararDado()
    {
        this.transform.position = posicionInicial;
        rbDado.velocity = new Vector3(0f, 0f, 0f);
        ejeX = Random.Range(0f, 271f);
        ejeY = Random.Range(0f, 271f);
        ejeZ = Random.Range(0f, 271f);
        this.transform.Rotate(ejeX, ejeY, ejeZ);
        ejeX = Random.Range(-3f,3f);
        ejeY = Random.Range(-2f,0f);
        ejeZ = Random.Range(-3f,3f);
        rbDado.AddForce(ejeX,ejeY,ejeZ, ForceMode.Impulse);

    }
}
