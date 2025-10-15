using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // player velocity
    public float velocidad = 5f;
    // gravity force in game
    public float gravedad = -9.8f;
    // piece that allows movement in the game
    private CharacterController controller;
    // tells us how fast we fall
    private Vector3 velocidadVertical;

    // which camera is the player's eyes
    public Transform camera;
    // mouse sensitivity
    public float sensibilidadMouse = 200f;
    // degrees of vision (vertical rotation)
    private float rotacionXVertical = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // get the CharacterController component
        controller = GetComponent<CharacterController>();
        // lock the cursor at the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ManejadorVista();
        ManejadorMovimiento();
    }

    void ManejadorVista()
    {
        // read the mouse input and build the horizontal rotation, register the vertical rotation, clamp vertical rotation, apply the rotation
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        // rotate horizontally
        transform.Rotate(Vector3.up * mouseX);

        // update vertical rotation, clamp between -90f and 90f
        rotacionXVertical -= mouseY;
        rotacionXVertical = Mathf.Clamp(rotacionXVertical, -90f, 90f);

        // apply the vertical rotation to the camera
        camera.localRotation = Quaternion.Euler(rotacionXVertical, 0, 0);
    }

    void ManejadorMovimiento()
    {
        // read movement input, create movement vector, move the character controller, apply gravity
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 direccion = transform.right * inputX + transform.forward * inputY;

        controller.Move(direccion * velocidad * Time.deltaTime);

        // check if we are on the ground for jumping
        if (controller.isGrounded && velocidadVertical.y < 0)
        {
            velocidadVertical.y = -2f;
        }

        // apply gravity
        velocidadVertical.y += gravedad * Time.deltaTime;

        // apply vertical velocity (falling/jumping)
        controller.Move(velocidadVertical * Time.deltaTime);
    }
}