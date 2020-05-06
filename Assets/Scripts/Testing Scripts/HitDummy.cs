using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDummy : MonoBehaviour
{
    private BoxCollider Ship;
    private float Health = 100;
    public GameObject Healthbar;
    public AudioClip CannonHit;
    //Text for hovering
    public GameObject Name;
    // Start is called before the first frame update
    void Start()
    {
        //Health and name
        Name.GetComponentInChildren<TextMesh>().text = "HitDummy";
        Healthbar.GetComponentInChildren<TextMesh>().text = Health + " HP";

        //Ship gets hit
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = CannonHit;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health == 0 || Health < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.name == "CannonBall(Clone)")
        {
            Debug.Log("HIT");
            Health = Health - 10;
            Healthbar.GetComponentInChildren<TextMesh>().text = Health + " HP";
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
    }
}
