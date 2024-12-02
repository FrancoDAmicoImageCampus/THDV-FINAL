using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;  // El jugador o el objeto al que la cámara sigue
    public float distance = 5f;  // Distancia a la que la cámara se encuentra del jugador
    public float height = 2f;  // Altura de la cámara con respecto al jugador
    public float rotationSpeed = 5f;  // Velocidad de rotación de la cámara

    private Vector3 offset;  // Desplazamiento relativo entre la cámara y el jugador

    void Start()
    {
        // Calculamos el desplazamiento inicial de la cámara
        offset = new Vector3(0, height, -distance);
    }

    void LateUpdate()
    {
        // Obtener la rotación del jugador en Y (para mantener el ángulo en X fijo)
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.RotateAround(player.position, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        // Fijar el ángulo en el eje X de la cámara
        Vector3 desiredPosition = player.position + offset;  // Obtener la posición deseada
        transform.position = desiredPosition;  // Establecer la posición de la cámara

        // Mirar al jugador con la cámara, manteniendo la rotación en X
        transform.LookAt(player.position);
    }
}