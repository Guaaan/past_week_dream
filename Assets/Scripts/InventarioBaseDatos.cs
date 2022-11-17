using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
public class InventarioBaseDatos : ScriptableObject
{
    public ObjetoInventario[] baseDatos;

}
[System.Serializable]
public struct ObjetoInventario
{
    public string nombre;
    public Sprite sprite;
    public enum uso
    {
        usable,
        equipable,
        consumible
    }
    public string caracteristicas;
}