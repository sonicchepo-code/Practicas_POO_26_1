using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraPro : MonoBehaviour
{
    // TODO: Referencia al objetivo (bola)
    public Transform objetivo;
    // TODO: Offset o separaci�n entre la c�mara y el objetivo
    public Vector3 offset = new Vector3(0f, 3f, -6f);
    // TODO: Variable para activar o desactivar el seguimiento
    private bool seguir = false;
    void LateUpdate()
    {
        // PISTA: Solo seguir si est� activado y el objetivo est� correctamente referenciado
        if (seguir && objetivo != null)
        {
            // PISTA: Posicionar c�mara con offset
            // transform.position = ???
            transform.position = objetivo.position + offset;
        }
    }
    // PISTA: M�todo para iniciar seguimiento
    public void IniciarSeguimiento()
    {
        seguir = true;
    }
    // PISTA: M�todo para detener seguimiento
    public void DetenerSeguimiento()
    {
        seguir = false;
    }
}