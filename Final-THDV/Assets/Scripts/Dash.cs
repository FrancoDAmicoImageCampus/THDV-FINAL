using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashDistance = 500f; // Distancia del dash
    public float dashCooldown = 1f; // Tiempo de recarga del dash
    private bool isDashing = false; // Estado de dash
    private float dashTimer; // Contador de tiempo para el cooldown
    private Rigidbody rb; // Componente Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Comprobar si se presiona la tecla Alt y si no se está dashing
        if (Input.GetKeyDown(KeyCode.LeftAlt) && !isDashing && dashTimer <= 0)
        {
            StartDash();
        }

        // Manejar el cooldown del dash
        if (dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
        }
    }

    void StartDash()
    {
        isDashing = true; // Activar modo dashing

        // Realizar el dash
        Vector3 dashDirection = transform.forward * dashDistance; // Dirección hacia adelante multiplicada por la distancia del dash
        rb.AddForce(dashDirection, ForceMode.Impulse); // Aplicar fuerza de dash

        // Reiniciar el dash después del tiempo de cooldown
        Invoke("ResetDash", 0.1f);
        dashTimer = dashCooldown; // Reiniciar el temporizador de cooldown
    }

    void ResetDash()
    {
        isDashing = false; // Resetear el estado de dashing
    }
}