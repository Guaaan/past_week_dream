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



    public void OnBeginDrag(PointerEventData eventData)
    {
        // le pongo el sprite al placeholder
        InventarioObjetoInterfacePlaceholder.current.sprite.sprite = sprite.sprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
        InventarioObjetoInterfacePlaceholder.current.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
