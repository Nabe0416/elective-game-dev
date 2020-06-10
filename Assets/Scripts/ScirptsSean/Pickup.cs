using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sean's code

public enum PickupTypes
{
    None,
    HP,
    Invincible
}

public class Pickup : MonoBehaviour
{


    [SerializeField]
    public PickupTypes PickupType;

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

    public void SetTypeTo(PickupTypes pt)
    {
        this.PickupType = pt;
    }

    public void SetHPRestoreAmountTo(int i)
    {
        this.HPRestoreAmount = i;
    }

    public void SetInvincibleTimeTo(float i)
    {
        this.InvincibleTime = i;
    }
}
