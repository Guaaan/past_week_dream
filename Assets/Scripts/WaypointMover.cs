using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    // guarda la referencia del sistema de waypoints que se van a usar
    [SerializeField] private Waypoints waypoints;

    [SerializeField] private float velocidad = 5f;
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
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, velocidad * Time.deltaTime);
       
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GettNextWaypoint(currentWaypoint);
        }
    }
}
