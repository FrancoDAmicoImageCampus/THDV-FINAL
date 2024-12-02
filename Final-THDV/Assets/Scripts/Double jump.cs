using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public float jumpForce = 5f; // Fuerza del salto
    private Rigidbody rb; // Componente Rigidbody
    private int jumpCount = 0; // Contador de saltos
    private const int maxJumpCount = 2; // Límite de saltos

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Comprobar si el jugador presiona la tecla de salto (por ejemplo, espacio)
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reseteamos la velocidad en y
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Aplicamos la fuerza de salto
        jumpCount++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reiniciar el contador de saltos al tocar el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0; // Reseteamos el contador de saltos
        }
    }
}