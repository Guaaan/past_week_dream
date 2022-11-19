using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioObjetoInterfacePlaceholder : MonoBehaviour
{
    public Image sprite;

    public static InventarioObjetoInterfacePlaceholder current;

    void Start()
    {
        if (current != null)
            Destroy(gameObject);

        sprite = GetComponent<Image>();
        current = this;
    }
}
