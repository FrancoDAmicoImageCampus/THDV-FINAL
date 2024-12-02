using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f;  // Radio de la explosi�n
    public float explosionForce = 700f; // Fuerza de la explosi�n

    // Start is called before the first frame update
    void Start()
    {
        // Hacemos que el objeto sea visible desde el principio
        gameObject.SetActive(true);

        // Llamamos a la corrutina para que el objeto explote y luego desaparezca
        StartCoroutine(ShowAndExplode());
    }

    // Corrutina para manejar la bomba
    IEnumerator ShowAndExplode()
    {
        // Esperamos 1 segundo antes de hacer la explosi�n
        yield return new WaitForSeconds(1f);

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
        }

        // Opcional: Efecto visual de la explosi�n (puedes agregar una animaci�n o part�cula aqu�)
        // Instanciar un efecto de explosi�n si es necesario, por ejemplo:
        // Instantiate(explosionEffect, transform.position, transform.rotation);
    }
}
