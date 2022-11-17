using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBilboard : MonoBehaviour
{
    [SerializeField] bool freezeXZAxis = true;
    // Update is called once per frame
    void Update()
    {
        if (freezeXZAxis)
        {
            //esta formula permite que el objeto en cuestión siga la cámara principal 
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f); 
        }
        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
