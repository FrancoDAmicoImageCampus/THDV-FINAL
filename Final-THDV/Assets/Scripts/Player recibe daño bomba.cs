using UnityEngine;
using TMPro; // Necesario para trabajar con TextMeshPro
using UnityEngine.SceneManagement;  // Necesario para cargar o reiniciar la escena

public class Player : MonoBehaviour
{
    public int health = 100;  // Salud inicial del jugador
    public TextMeshProUGUI healthText;  // Referencia al componente TextMeshProUGUI
    public float jumpForce = 5f;  // Fuerza del salto del jugador
    private Rigidbody rb;  // Componente Rigidbody del jugador para aplicar la física del salto

    public int maxHealth = 100;  // Salud máxima del jugador
    public float healthRegenerationRate = 10f;  // Tasa de regeneración de salud por segundo

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

        // Hacer que el jugador salte al recibir daño
        Jump();

        // Actualizar el texto en pantalla con la salud actual
        ActualizarSalud();
    }

    // Método que maneja la muerte del jugador
    private void Muerte()
    {
        Debug.Log("El jugador ha muerto");

        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Recarga la escena actual
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

    // Método para hacer que el jugador salte
    private void Jump()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();  // Obtiene el componente Rigidbody del jugador
        }

        if (rb != null && Mathf.Approximately(rb.velocity.y, 0f))  // Verifica si el jugador está en el suelo
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // Aplica una fuerza hacia arriba
            Debug.Log("El jugador ha saltado");
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

    // Método que maneja la regeneración de salud
    private void RegenerarSalud()
    {
        if (health < maxHealth)  // Si la salud no ha alcanzado el máximo
        {
            // Regenera salud según la tasa de regeneración
            health += (int)(healthRegenerationRate * Time.deltaTime);  // Calcula la cantidad de salud a regenerar por segundo
            if (health > maxHealth)  // Asegura que no supere la salud máxima
            {
                health = maxHealth;
            }
        }
    }

    // Para asegurar que el texto se actualice al iniciar el juego
    private void Start()
    {
        ActualizarSalud();  // Muestra la salud en la UI al inicio
    }

    // Actualización por cada frame
    private void Update()
    {
        RegenerarSalud();  // Llama al método de regeneración de salud
        ActualizarSalud();  // Asegura que la UI de salud se actualice en cada frame
    }
}