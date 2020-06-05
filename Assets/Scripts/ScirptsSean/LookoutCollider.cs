using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookoutCollider : MonoBehaviour
{

    private PirateShipController controller;
    private void Start()
    {
        controller = GetComponentInParent<PirateShipController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PirateShipController>() || other.GetComponent<Pickup>())
        {
            controller.LookoutAddItem(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (controller.objects.Contains(other.gameObject))
            controller.LookoutRemoveItem(other.gameObject);
    }
}
