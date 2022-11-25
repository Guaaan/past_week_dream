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
    bool estarAlerta;
    public float velocidad;

    public Quaternion angulo;
    public float cronometro;
    public float grado;
    public int rutina;

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
            cronometro += 1 * Time.deltaTime;
            switch (rutina)
            {
                case 0:
                    print("caso0");
                    rutina++;
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    print("caso1");
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    print("caso2");

                    break;
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
