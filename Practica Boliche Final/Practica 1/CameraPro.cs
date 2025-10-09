using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraPro : MonoBehaviour
{
    // TODO: Referencia al objetivo (bola)
    public Transform objetivo;
    // TODO: Offset o separación entre la cámara y el objetivo
    public Vector3 offset = new Vector3(0f, 3f, -6f);
    // TODO: Variable para activar o desactivar el seguimiento
    private bool seguir = false;
    void LateUpdate()
    {
        // PISTA: Solo seguir si está activado y el objetivo está correctamente referenciado
        if (seguir && objetivo != null)
        {
            // PISTA: Posicionar cámara con offset
            // transform.position = ???
            transform.position = objetivo.position + offset;
        }
    }
    // PISTA: Método para iniciar seguimiento
    public void IniciarSeguimiento()
    {
        seguir = true;
    }
    // PISTA: Método para detener seguimiento
    public void DetenerSeguimiento()
    {
        seguir = false;
    }
}