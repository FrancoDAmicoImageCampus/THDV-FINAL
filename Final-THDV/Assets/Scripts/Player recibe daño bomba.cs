using UnityEngine;
using TMPro; // Necesario para trabajar con TextMeshPro

public class Player : MonoBehaviour
{
    public int health = 100;  // Salud inicial del jugador
    public TextMeshProUGUI healthText;  // Referencia al componente TextMeshProUGUI

    // Método para recibir daño
    public void RecibirDanio(int cantidadDeDanio)
    {
        health -= cantidadDeDanio;
        Debug.Log("Salud del jugador: " + health);

        // Comprobar si la salud es menor o igual a 0 y manejar la muerte del jugador
        if (health <= 0)
        {
            Muerte();
        }

        // Actualizar el texto en pantalla con la salud actual
        ActualizarSalud();
    }

    // Método que maneja la muerte del jugador
    private void Muerte()
    {
        Debug.Log("El jugador ha muerto");
        // Aquí puedes agregar la lógica para la muerte, como reiniciar el nivel o mostrar una pantalla de Game Over
    }

    // Método para actualizar el texto que muestra la salud
    private void ActualizarSalud()
    {
        if (healthText != null)
        {
            // Actualiza el texto en el UI con la salud actual
            healthText.text = "Salud: " + health.ToString();
        }
    }

    // Si el jugador tiene un collider, puedes usar este método para detectar si ha sido golpeado por la explosión
    void OnCollisionEnter(Collision collision)
    {
        // Si el jugador colisiona con un objeto con el tag "Explosion" (o el que sea relevante)
        if (collision.gameObject.CompareTag("Explosion"))
        {
            // Aquí se puede aplicar el daño al jugador (por ejemplo, 20 de daño)
            RecibirDanio(20); // Ajusta el daño según lo necesario
        }
    }

    // Para asegurar que el texto se actualice al iniciar el juego
    private void Start()
    {
        ActualizarSalud();  // Muestra la salud en la UI al inicio
    }
}