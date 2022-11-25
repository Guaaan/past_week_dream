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
    bool estarAlerta;
    public float velocidad;

    void Start()
    {

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
            print("nada pasando por la cabeza del enemigo");
        }
    }
    private void OnDrawGizmos()
    {
        // le asigno el color y un wireframe al rangoDeAlerta
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
  
}
