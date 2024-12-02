using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f;  // Radio de la explosión
    public float explosionForce = 700f; // Fuerza de la explosión
    public int damage = 20;             // Daño de la explosión

    // Start is called before the first frame update
    void Start()
    {
        // Hacemos que el objeto sea visible desde el principio
        gameObject.SetActive(true);

        // Llamamos a la corrutina para que el objeto explote después de 3 segundos
        StartCoroutine(ShowAndExplode());
    }

    // Corrutina para manejar la bomba
    IEnumerator ShowAndExplode()
    {
        // Esperamos 3 segundos antes de hacer la explosión
        yield return new WaitForSeconds(3f); // Cambié el tiempo a 3 segundos

        // Creamos la explosión (destrucción de objetos cercanos con el tag "rompible")
        Explode();

        // Después de la explosión, esperamos un poco y luego desactivamos la bomba
        yield return new WaitForSeconds(0.5f); // Espera para que los efectos de la explosión sean visibles

        // Desactivamos la bomba después de un corto tiempo
        gameObject.SetActive(false);
    }

    // Función para manejar la explosión
    void Explode()
    {
        // Obtener todos los colliders dentro del radio de la explosión
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        // Iterar a través de todos los objetos que están dentro del radio
        foreach (Collider hitCollider in hitColliders)
        {
            // Si el objeto tiene el tag "rompible"
            if (hitCollider.CompareTag("rompible"))
            {
                // Destruimos el objeto
                Destroy(hitCollider.gameObject);

                // Si deseas aplicar fuerza (como una explosión) a los objetos cercanos, puedes hacerlo así:
                Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // Aplicamos una fuerza de explosión hacia afuera desde el centro
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }

            // Si el objeto tiene el tag "Player", aplicar daño
            if (hitCollider.CompareTag("Player"))
            {
                Player player = hitCollider.GetComponent<Player>();
                if (player != null)
                {
                    // Llamamos a la función para que el jugador reciba daño
                    player.RecibirDanio(damage);
                }
            }
        }

        // Opcional: Efecto visual de la explosión (puedes agregar una animación o partícula aquí)
        // Instanciar un efecto de explosión si es necesario, por ejemplo:
        // Instantiate(explosionEffect, transform.position, transform.rotation);
    }
}