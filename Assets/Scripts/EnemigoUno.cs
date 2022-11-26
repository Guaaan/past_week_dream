// de momento el enemigo no ataca, ver el final de este video https://www.youtube.com/watch?v=jxoY5kBtCRQ
// TODO: hacer que el enemigo ataque
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemigoUno : MonoBehaviour
{
    //rango en que el enemigo detecta al jugador
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;

    public Transform jugador;
    public Transform wayPoint;
    public bool estarAlerta;
    public float velocidad;


    // guarda la referencia del sistema de waypoints que se van a usar
    [SerializeField] private Waypoints waypoints;

    [SerializeField] private float distanceThreshold = 0.1f;
    // el waypoint actual al que se mueve el personaje
    private Transform currentWaypoint;

    void Start()
    {
        //asignar posición inicial
        currentWaypoint = waypoints.GettNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // asignar el proximo waypoint objetivo
        currentWaypoint = waypoints.GettNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        if (estarAlerta == true)
        {
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime); ;
        }
        else
        {
            print("te agarré wacho vení que te reviento");
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, velocidad * Time.deltaTime);
            transform.LookAt(currentWaypoint);

            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                currentWaypoint = waypoints.GettNextWaypoint(currentWaypoint);
                transform.LookAt(currentWaypoint);
            }
        }
    }
    private void OnDrawGizmos()
    {
        // le asigno el color y un wireframe al rangoDeAlerta
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }

}
