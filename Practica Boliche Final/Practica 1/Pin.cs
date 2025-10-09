using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pin : MonoBehaviour
{
    // Umbral de inclinación 
    private float umbralCaida = 5f;
    // Método para determinar si el pin está caído
    public bool EstaCaido()
    {
        // Calcular el ángulo entre la orientación del pin (transform.up) y el eje vertical (Vector3.up)
        float angulo = Vector3.Angle(transform.up, Vector3.up);
        // Retornar true si el ángulo supera el umbral de caída
        return angulo > umbralCaida;
    }
}