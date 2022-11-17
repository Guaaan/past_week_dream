using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarraObjeto : MonoBehaviour
{
    // referencio mi objeto en mano
    public GameObject handPoint;

    private GameObject pickedObject = null;


    void Update()
    {
        if (pickedObject != null)
        {
            if (Input.GetKey("r"))
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        //si el tag es objeto
        if (other.gameObject.CompareTag("Objeto"))
        {
            // si se presiona la e y no hay nada en mano
            if (Input.GetKey("e") && pickedObject == null)
            {
                // le desactivo la gravedad
                other.GetComponent<Rigidbody>().useGravity = true;

                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = handPoint.transform.position;

                other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                pickedObject = other.gameObject;
            }
        }
    }
}
