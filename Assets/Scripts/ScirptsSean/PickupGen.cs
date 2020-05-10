using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupGen : MonoBehaviour
{
    public GameObject PickupPrefab;

    [SerializeField]
    [Tooltip("Time (in sec) between generating 2 pickups.")]
    private float SecPerPickup = 1f; //Time (in sec)
    [SerializeField]
    [Tooltip("Ratio of generating a pickup per time. Doesn't have to be 100 in total.")]
    private float RatioHealth = 30, RatioInvin = 5; //Ratio of generating a pickup per time. Doesn't have to be 1 in total.
    [SerializeField]
    [Tooltip("Max amount of pickups that can be spawned in the map.")]
    private int MaxPickups = 5; //Max amount of pickups that can be spawned in the map.

    [SerializeField]
    [Tooltip("The area that the pickup can be spawned in.")]
    private Vector2 FieldSize = new Vector2 (100, 100);

    public bool LogResultInConsole = false;
    public bool StartGenerating = false;

    private float YAxisOfPickups = 10;

    [SerializeField]
    [Tooltip("Don't change this. Check if colliding with ships.")]
    private bool isCollidingWithShip;
    [SerializeField]
    [Tooltip("Size of area that will be checked. 50 is about just as large as a ship takes.")]
    private float DetectSize = 100f;

    [SerializeField]
    [Tooltip("The amount of restored HP per pickup.")]
    private int HPRestore = 20;

    [SerializeField]
    [Tooltip("Invincible time in secs per pick up")]
    private float InvinSec = 5;

    private void Start()
    {
        GetComponent<SphereCollider>().radius = DetectSize;
        StartCoroutine(GeneratePickups());
    }

    IEnumerator GeneratePickups()
    {
        if(StartGenerating)
        {
            int count;
            count = FindObjectsOfType<Pickup>().Length;
            if(count >= MaxPickups)
            {
                Destroy(FindObjectsOfType<Pickup>()[4].gameObject);
            }
            if (LogResultInConsole)
            {
                print("======Start Attempting======");
            }

            var pos = GenPosition();
            this.transform.position = pos;
            if(!isCollidingWithShip)
            {
                if (LogResultInConsole)
                    print("No ship detected, continue with generating.");
                var puType = GeneratePickupType();
                if(puType != PickupTypes.None)
                {
                    var pickup = Instantiate(PickupPrefab, pos, Quaternion.identity);
                    if (LogResultInConsole)
                        print("Pickup generated at " + pickup.transform.position + ".");
                    var pu = pickup.GetComponent<Pickup>();

                    pu.SetTypeTo(puType);
                    if (LogResultInConsole)
                        print("Type of generated pickup is " + puType.ToString());
                        if (puType == PickupTypes.Invincible)
                        {
                            pu.SetInvincibleTimeTo(InvinSec);
                        }
                        else if (puType == PickupTypes.HP)
                        {
                            pu.SetHPRestoreAmountTo(HPRestore);
                        }
                }
                else
                {
                    if (LogResultInConsole)
                        print("Pickup type is none, no pickup will be generated. Next attempting after " + SecPerPickup + " second(s).");
                }
            }
            else
            {
                if (LogResultInConsole)
                    print("Ship(s) detected, next attempting after " + SecPerPickup + " second(s).");
            }
            if (LogResultInConsole)
                print("======End Attempting======");
        }
        else
        {
            if (LogResultInConsole)
                print("Please check [Start generating] to start the generation");
        }

        yield return new WaitForSeconds(SecPerPickup);
        StartCoroutine(GeneratePickups());
    }

    Vector3 GenPosition()
    {
        return new Vector3(Random.Range(-FieldSize.x, FieldSize.x), YAxisOfPickups, Random.Range(-FieldSize.y, FieldSize.y));
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<PirateShipController>())
        {
            isCollidingWithShip = true;
        }
        else
        {
            isCollidingWithShip = false;
        }
    }
    PickupTypes GeneratePickupType()
    {
        float random = Random.Range(0, 100);
        if(random <= RatioInvin)
        {
            return PickupTypes.HP;
        }else if(random <= RatioHealth)
        {
            return PickupTypes.HP;
        }
        else
        {
            return PickupTypes.None;
        }
    }
}
