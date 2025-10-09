using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    // TODO: Texto UI
    public Text textoPuntaje;
    // TODO: Variables internas
    private int puntajeActual = 0;
    private Pin[] pinos;
    void Start()
    {
        // PISTA: Buscar todos los objetos tipo Pin
        // pinos = ???
        pinos = GetComponentsInChildren<Pin>();
    }
    public void CalcularPuntaje()
    {
        int puntaje = 0;
        // PISTA: Revisar cada pino si está caído
        foreach (Pin pin in pinos)
        {
            // if (pin.EstaCaido()) { puntaje++; }
            if (pin.EstaCaido())
            {
                puntaje++;
            }
        }
        puntajeActual = puntaje;
        // PISTA: Actualizar texto del puntaje (validar si textoPuntaje != null)
        // if (textoPuntaje != null) textoPuntaje.text = "Puntos: " + puntajeActual;
        if (textoPuntaje != null)
        {
            textoPuntaje.text = "Puntos: " + puntajeActual;
            
        }
    }
}