using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventarioObjetoInterfacePlaceholder : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image sprite;

    public static InventarioObjetoInterfacePlaceholder current;

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // al soltarlo quito el sprite
        sprite.sprite = null;
    }

    void Start()
    {
        if (current != null)
            Destroy(gameObject);

        sprite = GetComponent<Image>();
        current = this;
    }
}
