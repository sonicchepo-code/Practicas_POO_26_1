using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pin : MonoBehaviour
{
    // Umbral de inclinaci�n 
    private float umbralCaida = 5f;
    // M�todo para determinar si el pin est� ca�do
    public bool EstaCaido()
    {
        // Calcular el �ngulo entre la orientaci�n del pin (transform.up) y el eje vertical (Vector3.up)
        float angulo = Vector3.Angle(transform.up, Vector3.up);
        // Retornar true si el �ngulo supera el umbral de ca�da
        return angulo > umbralCaida;
    }
}