using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupTypes
    {
        None,
        HP,
        Invincible
    }

    [SerializeField]
    private PickupTypes PickupType;

    [SerializeField]
    private int HPRestoreAmount = 0;

    [SerializeField]
    private float InvincibleTime = 0;

    private void OnTriggerEnter(Collider other)
    {
        var ship = other.gameObject.GetComponent<PirateShipController>();
        if(ship)
        {
            switch (this.PickupType)
            {
                case PickupTypes.None:
                    break;
                case PickupTypes.HP:
                    ship.AdjustHP(HPRestoreAmount);
                    print("HP ADDED " + HPRestoreAmount);
                    break;
                case PickupTypes.Invincible:
                    ship.SetInvincible(InvincibleTime);
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
