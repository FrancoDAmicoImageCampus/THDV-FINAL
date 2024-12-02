using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para manejar la UI

public class Pausa : MonoBehaviour
{
    // Referencia al panel de pausa
    public GameObject panelPausa;

    // Variable para controlar si el juego está pausado
    private bool juegoPausado = false;

    // Referencia al script que controla el movimiento de la cámara (asegúrate de asignarlo en el Inspector)
    public MonoBehaviour movimientoCamara;

    // Referencia al botón para reanudar
    public Button botonReanudar;

    // Start se llama antes del primer frame
    void Start()
    {
        // Asegúrate de que el panel de pausa esté desactivado al inicio
        panelPausa.SetActive(false);

        // Ocultar el cursor y bloquearlo al inicio
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Asignar el método ReanudarJuego al evento onClick del botón
        if (botonReanudar != null)
        {
            botonReanudar.onClick.AddListener(ReanudarJuego);
        }
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Detectar si el jugador presiona la tecla "V"
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    // Método para pausar el juego
    void PausarJuego()
    {
        Time.timeScale = 0f; // Detener el tiempo del juego
        panelPausa.SetActive(true); // Mostrar el panel de pausa

        // Desactivar el movimiento de la cámara
        if (movimientoCamara != null)
        {
            movimientoCamara.enabled = false; // Deshabilitar el script de movimiento de la cámara
        }

        // Mostrar el cursor y desbloquearlo
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        juegoPausado = true; // Marcar el estado como pausado
    }

    // Método para reanudar el juego
    public void ReanudarJuego()
    {
        Time.timeScale = 1f; // Reanudar el tiempo del juego
        panelPausa.SetActive(false); // Ocultar el panel de pausa

        // Reactivar el movimiento de la cámara
        if (movimientoCamara != null)
        {
            movimientoCamara.enabled = true; // Habilitar nuevamente el script de movimiento de la cámara
        }

        // Ocultar el cursor y bloquearlo
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        juegoPausado = false; // Marcar el estado como no pausado
    }
}