using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paredmovil : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de movimiento de la pared.
    public float distancia = 5f; // Distancia m�xima que recorrer� de un lado a otro.

    private Vector3 posicionInicial; // Posici�n inicial de la pared.
    private int direccion = 1; // Direcci�n del movimiento (1 para derecha, -1 para izquierda).

    // Start se llama al inicio.
    void Start()
    {
        // Guarda la posici�n inicial de la pared.
        posicionInicial = transform.position;
    }

    // Update se llama una vez por frame.
    void Update()
    {
        // Calcula el movimiento de la pared.
        float movimiento = velocidad * Time.deltaTime * direccion;
        transform.position += new Vector3(movimiento, 0, 0);

        // Comprueba si la pared ha alcanzado el l�mite de distancia y cambia de direcci�n.
        if (Vector3.Distance(posicionInicial, transform.position) >= distancia)
        {
            direccion *= -1; // Invierte la direcci�n.
        }
    }
}
