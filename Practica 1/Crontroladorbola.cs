using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controladorbola : MonoBehaviour
{

    public Transform CamaraPrincipal;

    public Rigidbody rb;  //manipulacion a lo largo del codigo el rb

    //Variables para apuntar
    public float velocidadDeApuntado = 5f;
    public float limiteIzquierdo = -2f;
    public float limiteDerecho = 2f;



    public float fuerzaDeLanzamiento = 1000f;

    private bool haSidoLanzada = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {     //Expresión:mientras que haSidoLanzada sea falso puedes disparar

        if (haSidoLanzada == false)
        {
            Apuntar();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();
            }
        }
    }

    void Apuntar()
    {
        //1. Leer un input horizontal de tipo Axis, te permite registrar 
        //entradas con las teclas A y D, y Flecha izquierda y Flecha derecha
        float inputHorizontal = Input.GetAxis("Horizontal");

        //2. Mover la bola hacia los lados
        transform.Translate(Vector3.right * inputHorizontal * velocidadDeApuntado * Time.deltaTime);

        //3. Delimitar el movimiento de la bola
        Vector3 posicionActual = transform.position;  //transformPosition me permite saber cual es la
                                                      //posicion actual de la bola en la escena
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);

        transform.position = posicionActual;   // limites de la bola
    }

    void Lanzar()
    {
        haSidoLanzada = true;
        rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);

        if (CamaraPrincipal != null)
        {
            CamaraPrincipal.SetParent(transform);
        }

    }

} // Bienvenido a la entrada al infierno