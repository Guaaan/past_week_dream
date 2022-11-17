using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioCollider : MonoBehaviour
{
    InventarioManager m;

    private void Start()
    {
        m = GetComponent<InventarioManager>();
    }
    // si el objeto no es nulo recoge el objeto
    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<InventarioObjetoRecogible>() != null)
        {
            InventarioObjetoRecogible i = col.GetComponent<InventarioObjetoRecogible>();
            m.AgregarAlgoAlInventario(i.id, i.cantidad);
            Destroy(col.gameObject);
        }
    }
}
