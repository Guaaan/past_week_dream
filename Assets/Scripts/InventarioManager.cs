using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioManager : MonoBehaviour
{
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

    public void AgregarAlgoAlInventario(int id, int cantidad)
    {
        for( int i = 0;i< inventario.Count; i++)
        {
            if (inventario[i].id == id)
            {
                inventario[i].sumarCantidad(cantidad);
                return;
            }
        }
        ObjetoInventarioId n = new ObjetoInventarioId();
        n.id = id;
        n.cantidad = cantidad;
        inventario.Add(n);
    }
}
