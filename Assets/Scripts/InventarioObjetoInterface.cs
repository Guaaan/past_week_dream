using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventarioObjetoInterface : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public TMP_Text cantidad;
    public Image sprite;
    public Button boton;
    public int id;

    public InventarioManager manager;

    public static InventarioObjetoInterface arrastrando;

    public void OnBeginDrag(PointerEventData eventData)
    {
        arrastrando = this;
        // le pongo el sprite al placeholder
        InventarioObjetoInterfacePlaceholder.current.sprite.sprite = sprite.sprite;

    }

    public void OnDrag(PointerEventData eventData)
    {
        InventarioObjetoInterfacePlaceholder.current.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        arrastrando = null;
        InventarioObjetoInterfacePlaceholder.current.transform.position = new Vector3(10000, 1000, 100);
    }
    public void OnDrop(PointerEventData data)
    {
        // si arrastramos a un espacio vacío
        if (arrastrando == null)
            return;
        // si arrastramos al mismo objeto que tomamos
        if (arrastrando == this)
            return;

        manager.IntercambiarPuestos(id, arrastrando.id);
    }
}
