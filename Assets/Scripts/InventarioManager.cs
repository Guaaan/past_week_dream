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

        // public void sumarCantidad(int cantidad)
        // {
        //     this.cantidad += cantidad;
        // }
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
                inventario[i] = new ObjetoInventarioId(inventario[i].id, inventario[i].cantidad + cantidad);
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
        for (int i = 0; i < inventario.Count; i++)
        {
            if (inventario[i].id == id)
            {
                // si hay más de uno le resto la cantidad
                inventario[i] = new ObjetoInventarioId(inventario[i].id, inventario[i].cantidad - cantidad);
                // si queda en cero elimino el item
                if (inventario[i].cantidad <= 0)
                    inventario.Remove(inventario[i]);
                ActualizarInventario();
                return;
            }
        }
        Debug.LogError("No existe el objeto a eliminar");
    }

    public void IntercambiarPuestos(int i1, int i2)
    {
        ObjetoInventarioId i = inventario[i1];
        inventario[i1] = inventario[i2];
        inventario[i2] = i;
        ActualizarInventario();
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
        print("inventario actualizado");
        for (int i = 0; i < pool.Count; i++)
        {
            if (i < inventario.Count)
            {
                ObjetoInventarioId o = inventario[i];
                pool[i].sprite.sprite = baseDatos.baseDatos[o.id].sprite;
                pool[i].cantidad.text = o.cantidad.ToString();

                pool[i].id = i;


                // elimina todos los los listeners del boton lo que lo deja sirviendo para nada
                pool[i].boton.onClick.RemoveAllListeners();
                // le  agrego la funcion al boton para
                pool[i].boton.onClick.AddListener(() => gameObject.SendMessage(baseDatos.baseDatos[o.id].funcion, SendMessageOptions.DontRequireReceiver));


                pool[i].gameObject.SetActive(true);
            }
            else
            {
                pool[i].gameObject.SetActive(false);
            }
        }
        if (inventario.Count > pool.Count)
        {
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
                pool[i].id = i;
                pool[i].manager = this;

                pool[i].boton.onClick.RemoveAllListeners();
                pool[i].boton.onClick.AddListener(() => gameObject.SendMessage(baseDatos.baseDatos[o.id].funcion, SendMessageOptions.DontRequireReceiver));

                pool[i].gameObject.SetActive(true);
            }
        }
    }

    public void Cerebro()
    {
        // recibe el id y luego la cantidad que elimina
        EliminarAlgoDeInventario(0, 1);
        print("el alma se te llena de ideas que no te pertenecen y te sientes cansado");
    }
}
