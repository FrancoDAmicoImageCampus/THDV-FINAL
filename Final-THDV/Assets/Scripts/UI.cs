using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena.

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damageAmount = 10;
    public TextMeshProUGUI healthText;

    void Start()
    {
        // Inicializa la salud actual y actualiza el texto.
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    void Update()
    {
        // Comprueba si se presiona la tecla R y reduce la salud.
        if (Input.GetKeyDown(KeyCode.R))
        {
            DecreaseHealth(damageAmount);
        }
    }

    public void DecreaseHealth(int amount)
    {
        // Reduce la salud y evita que sea menor a 0.
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        // Actualiza el texto con la nueva salud.
        UpdateHealthText();

        // Si la salud llega a 0, reinicia la escena.
        if (currentHealth <= 0)
        {
            Debug.Log("El jugador ha muerto. Reiniciando nivel...");
            RestartLevel();
        }
    }

    void UpdateHealthText()
    {
        // Actualiza el texto de TextMeshPro con la salud actual.
        if (healthText != null)
        {
            healthText.text = "Salud: " + currentHealth;
        }
        else
        {
            Debug.LogWarning("El objeto TextMeshPro no está asignado.");
        }
    }

    void RestartLevel()
    {
        // Reinicia la escena actual.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}