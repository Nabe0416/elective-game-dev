using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicManualMovement : MonoBehaviour
{
    private Rigidbody rBody;
    private float TestSpeed = 25;
    private float inputMovement;

    //Health
    private float Health = 100;
    public GameObject Healthbar;
    //Text for hovering
    public GameObject Name;


    //Copied from the PirateShipController.cs Old file
    public GameObject CannonBallPrefab;
    public Transform CannonFrontSpawnPoint;
    public Transform CannonLeftSpawnPoint;
    public Transform CannonRightSpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        Name.GetComponentInChildren<TextMesh>().text = "TestShip";
        Healthbar.GetComponentInChildren<TextMesh>().text = Health + " HP";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Basic movement
        rBody.velocity = new Vector3(Input.GetAxis("Horizontal") * (TestSpeed* 1000) * Time.deltaTime, 0f, Input.GetAxis("Vertical") * (TestSpeed * 1000) * Time.deltaTime);
        //Basic Shooting forward
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            GameObject newInstance = Instantiate(CannonBallPrefab, CannonFrontSpawnPoint.position, CannonFrontSpawnPoint.rotation);
        }

    }
}
