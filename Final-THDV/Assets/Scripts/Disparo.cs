using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    // Prefab de la bala
    public GameObject balaPrefab;

    // Punto de origen del disparo
    public Transform puntoDisparo;

    // Velocidad de la bala
    public float velocidadBala = 20f;

    // L�mite de balas activas
    public int maxBalas = 5;

    // Lista para rastrear las balas activas
    private List<GameObject> balasActivas = new List<GameObject>();

    void Update()
    {
        // Detectar clic izquierdo para disparar
        if (Input.GetMouseButtonDown(0)) // Bot�n 0 es el clic izquierdo
        {
            Disparar();
        }

        // Detectar clic derecho para eliminar todas las balas
        if (Input.GetMouseButtonDown(1)) // Bot�n 1 es el clic derecho
        {
            EliminarTodasLasBalas();
        }
    }

    // M�todo para disparar
    void Disparar()
    {
        // Verificar si no hemos excedido el l�mite de balas activas
        if (balasActivas.Count < maxBalas && balaPrefab != null && puntoDisparo != null)
        {
            // Instanciar la bala en el punto de disparo
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

            // Aplicar movimiento a la bala
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = puntoDisparo.forward * velocidadBala;
            }

            // Agregar la bala a la lista de balas activas
            balasActivas.Add(bala);
        }
        else
        {
            Debug.Log("Se alcanz� el l�mite de balas activas.");
        }
    }

    // M�todo para eliminar todas las balas
    void EliminarTodasLasBalas()
    {
        foreach (GameObject bala in balasActivas)
        {
            if (bala != null)
            {
                Destroy(bala);
            }
        }

        // Limpiar la lista de balas activas
        balasActivas.Clear();
    }
}