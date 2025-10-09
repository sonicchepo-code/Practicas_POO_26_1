using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// Controla el movimiento lateral y el lanzamiento de la bola.
/// También se comunica con la cámara y el sistema de puntuación
public class BallController : MonoBehaviour
{
    // TODO: Fuerza con la que se lanza la bola
    public float fuerzaDeLanzamiento = 1000f;
    // TODO: Velocidad y límites para el apuntado
    public float velocidadDeApuntado = 5f;
    public float limiteIzquierdo = -2f;
    public float limiteDerecho = 2f;
    // TODO: Referencias internas
    private Rigidbody rb;
    private bool haSidoLanzada = false;
    // TODO: Referencia a la cámara y score
    public Camera cameraFollow;
    public Score scoreManager;
    void Start()
    {
        // Obtener el componente Rigidbody de la bola
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!haSidoLanzada)
        {
            Apuntar();
            // Si se presiona espacio, lanzar la bola
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LanzarBola();
            }
        }
    }
    void Apuntar()
    {
        // Obtener el movimiento horizontal (-1 a 1)
        float inputHorizontal = Input.GetAxis("Horizontal");
        // Mover la bola lateralmente
        transform.Translate(Vector3.right * inputHorizontal * velocidadDeApuntado * Time.deltaTime);
        // Limitar el movimiento dentro de los bordes del carril
        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
        transform.position = posicionActual;
    }
    void LanzarBola()
    {
        haSidoLanzada = true;
        if (rb != null)
        {
            // Lanzar la bola hacia adelante (por el eje Z)
            rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);
        }
        else
        {
            Debug.LogWarning("⚠ El Rigidbody no está asignado en " + gameObject.name);
        }
        // Iniciar seguimiento de la cámara (si existe)
        if (cameraFollow != null)
        {
            // Hacer que la cámara siga la posición de la bola (mantener la altura y profundidad fijas)
            cameraFollow.transform.position = new Vector3(transform.position.x, cameraFollow.transform.position.y, cameraFollow.transform.
            position.z);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Si colisiona con un pino
        if (collision.gameObject.CompareTag("Pin"))
        {
            // Detener seguimiento de cámara (si no es null)
            if (cameraFollow != null)
            {


                // Se puede hacer que la cámara se quede en una posición fija
                cameraFollow.transform.position = new Vector3(cameraFollow.transform.position.x, cameraFollow.transform.position.y,
                cameraFollow.transform.position.z);
            }
            // Calcular puntaje 
            if (scoreManager != null)
            {
                Invoke("CalcularPuntaje", 2f); // Llama a CalcularPuntaje después de 2 segundos
            }
        }
    }
    void CalcularPuntaje()
    {
        // Llamar al ScoreManager para actualizar puntos
        if (scoreManager != null)
        {
            scoreManager.CalcularPuntaje(); // Llama al método para calcular el puntaje
        }
    }
}
