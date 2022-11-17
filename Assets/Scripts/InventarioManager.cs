using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioManager : MonoBehaviour
{
    //construyo la struct objeto del inventario
    [System.Serializable]
    public struct ObjetoInventarioId
    {
        public int id;
        public int cantidad;

        public ObjetoInventarioId(int id, int cantidad)
        {
            this.id = id;
            this.cantidad = cantidad;

        }

        public void sumarCantidad(int cantidad)
        {
            this.cantidad += cantidad;
        }
    }


    public InventarioBaseDatos baseDatos;
    public List<ObjetoInventarioId> inventario;

    //agrego al inventario
    public void AgregarAlgoAlInventario(int id, int cantidad)
    {
        for (int i = 0; i < inventario.Count; i++)
        {
            // si existe en la lista no lo agrego sino que sumo
            if (inventario[i].id == id)
            {
                inventario[i].sumarCantidad(cantidad);
                ActualizarInventario();
                return;
            }
        }
        // si no existe en la lista lo agrego nuevo
        inventario.Add(new ObjetoInventarioId(id, cantidad));
        ActualizarInventario();
    }

    public void EliminarAlgoDeInventario(int id, int cantidad)
    {
        for (int i = 0; i > inventario.Count; i++)
        {
            if (inventario[i].id == id)
            {
                // si hay más de uno le resto la cantidad
                inventario[i].sumarCantidad(-cantidad);
                // si queda en cero elimino el item
                if (inventario[i].cantidad <= 0)
                    inventario.Remove(inventario[i]);
                ActualizarInventario();
                return;
            }
        }
        Debug.LogError("No exite el objeot a eliminar");
    }

    public void Start()
    {
        ActualizarInventario();
    }

    public InventarioObjetoInterface prefab;
    public Transform inventarioUI;
    // pool es los objetos que no sabemos si vamos a utilizar así que lo desactivamos
    List<InventarioObjetoInterface> pool = new List<InventarioObjetoInterface>();

    public void ActualizarInventario()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (i < inventario.Count)
            {
                ObjetoInventarioId o = inventario[i];
                pool[i].sprite.sprite = baseDatos.baseDatos[o.id].sprite;
                pool[i].cantidad.text = o.cantidad.ToString();
                pool[i].gameObject.SetActive(true);
            }
            else
            {
                pool[i].gameObject.SetActive(false);
            }
        }
        {
            if (inventario.Count > pool.Count)
                for (int i = pool.Count; i < inventario.Count; i++)
                {
                    InventarioObjetoInterface oi = Instantiate(prefab, inventarioUI);
                    pool.Add(oi);
                    // escala y posiciona automaticamente en el canvas
                    oi.transform.position = Vector3.zero;
                    oi.transform.localScale = Vector3.one;

                    ObjetoInventarioId o = inventario[i];
                    pool[i].sprite.sprite = baseDatos.baseDatos[o.id].sprite;
                    pool[i].cantidad.text = o.cantidad.ToString();
                    pool[i].gameObject.SetActive(true);
                }
        }
    }

}
