using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioCanvas : MonoBehaviour
{
    public GameObject Inventario;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            // activo el inventario si está desactivado
            // y lo desactivo si está activo
            Inventario.SetActive(!Inventario.activeInHierarchy);
        }
        if (Inventario.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
