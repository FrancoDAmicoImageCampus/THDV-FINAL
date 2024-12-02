using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f;  // Radio de la explosi�n
    public float explosionForce = 700f; // Fuerza de la explosi�n
    public int damage = 20;             // Da�o de la explosi�n

    // Start is called before the first frame update
    void Start()
    {
        // Hacemos que el objeto sea visible desde el principio
        gameObject.SetActive(true);

        // Llamamos a la corrutina para que el objeto explote despu�s de 3 segundos
        StartCoroutine(ShowAndExplode());
    }

    // Corrutina para manejar la bomba
    IEnumerator ShowAndExplode()
    {
        // Esperamos 3 segundos antes de hacer la explosi�n
        yield return new WaitForSeconds(3f); // Cambi� el tiempo a 3 segundos

        // Creamos la explosi�n (destrucci�n de objetos cercanos con el tag "rompible")
        Explode();

        // Despu�s de la explosi�n, esperamos un poco y luego desactivamos la bomba
        yield return new WaitForSeconds(0.5f); // Espera para que los efectos de la explosi�n sean visibles

        // Desactivamos la bomba despu�s de un corto tiempo
        gameObject.SetActive(false);
    }

    // Funci�n para manejar la explosi�n
    void Explode()
    {
        // Obtener todos los colliders dentro del radio de la explosi�n
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        // Iterar a trav�s de todos los objetos que est�n dentro del radio
        foreach (Collider hitCollider in hitColliders)
        {
            // Si el objeto tiene el tag "rompible"
            if (hitCollider.CompareTag("rompible"))
            {
                // Destruimos el objeto
                Destroy(hitCollider.gameObject);

                // Si deseas aplicar fuerza (como una explosi�n) a los objetos cercanos, puedes hacerlo as�:
                Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // Aplicamos una fuerza de explosi�n hacia afuera desde el centro
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }

            // Si el objeto tiene el tag "Player", aplicar da�o
            if (hitCollider.CompareTag("Player"))
            {
                Player player = hitCollider.GetComponent<Player>();
                if (player != null)
                {
                    // Llamamos a la funci�n para que el jugador reciba da�o
                    player.RecibirDanio(damage);
                }
            }
        }

        // Opcional: Efecto visual de la explosi�n (puedes agregar una animaci�n o part�cula aqu�)
        // Instanciar un efecto de explosi�n si es necesario, por ejemplo:
        // Instantiate(explosionEffect, transform.position, transform.rotation);
    }
}