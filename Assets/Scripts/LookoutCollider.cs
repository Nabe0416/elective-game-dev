using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameItems
{
    Border,
    Opponent,
    Pickup_HP,
    Pickup_Invin
}

public class LookoutCollider : MonoBehaviour
{

    private PirateShipController controller;
    private void Start()
    {
        controller = GetComponentInParent<PirateShipController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PirateShipController>())
        {
            controller.LookoutAddItem(GameItems.Opponent);
        }else if(other.GetComponent<Pickup>() && other.GetComponent<Pickup>().PickupType == PickupTypes.HP)
        {
            controller.LookoutAddItem(GameItems.Pickup_HP);
        }else if(other.GetComponent<Pickup>() && other.GetComponent<Pickup>().PickupType == PickupTypes.Invincible)
        {
            controller.LookoutAddItem(GameItems.Pickup_Invin);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PirateShipController>())
        {
            controller.LookoutRemoveItem(GameItems.Opponent);
        }
        else if (other.GetComponent<Pickup>() && other.GetComponent<Pickup>().PickupType == PickupTypes.HP)
        {
            controller.LookoutRemoveItem(GameItems.Pickup_HP);
        }
        else if (other.GetComponent<Pickup>() && other.GetComponent<Pickup>().PickupType == PickupTypes.Invincible)
        {
            controller.LookoutRemoveItem(GameItems.Pickup_Invin);
        }
    }
}
