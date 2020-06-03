using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShipController : MonoBehaviour
{
    public GameObject CannonBallPrefab = null;
    public Transform CannonFrontSpawnPoint = null;
    public Transform CannonLeftSpawnPoint = null;
    public Transform CannonRightSpawnPoint = null;
    public GameObject Lookout = null;
    public GameObject[] sails = null;
    private BaseAI ai = null;

    private float BoatSpeed = 100.0f;
    private float SeaSize = 500.0f;
    private float RotationSpeed = 180.0f;

    #region Sean's code
    #region HP and pickups
    private int HPMax = 100;
    [SerializeField]
    private int CurrentHP;

    [SerializeField]
    private bool isInvincible;
    
    private void OnEnable()
    {
        CurrentHP = HPMax;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!isInvincible)
        {
            if (collision.gameObject.GetComponent<CannonBall>())
            {
                CurrentHP -= 10;
                Destroy(collision.gameObject);
                if (CurrentHP <= 0)
                {
                    Sink();
                }
            }
        }
    }

    private void Sink()
    {
        Destroy(this.gameObject);//Temp method to destroy a ship when HP is 0. Add visual effect or whatever later.
    }

    public void AdjustHP(int i)
    {
        this.CurrentHP += i;
        if (CurrentHP > HPMax)
            CurrentHP = HPMax;
        if (CurrentHP <= 0)
            Sink();
    }

    public void SetInvincible(float f)
    {
        StartCoroutine(BeInvincibleFor(f));
        //Add some fansy visual effect here.
    }

    IEnumerator BeInvincibleFor(float f)
    {
        isInvincible = true;
        yield return new WaitForSeconds(f);
        isInvincible = false;
    }

    #endregion
    #region Lookout
    [SerializeField]
    private List<GameItems> objects = new List<GameItems>();

    public void LookoutAddItem(GameItems gi)
    {
        objects.Add(gi);
    }

    public void LookoutRemoveItem(GameItems gi)
    {
        if (objects.Contains(gi))
            objects.Remove(gi);
    }
    #endregion
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetAI(BaseAI _ai) {
        ai = _ai;
        ai.Ship = this;
    }

    public void StartBattle() {
        //Debug.Log("test");
        StartCoroutine(ai.RunAI());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    void OnTriggerStay(Collider other) {
        if (other.tag == "Boat") {
            ScannedRobotEvent scannedRobotEvent = new ScannedRobotEvent();
            scannedRobotEvent.Distance = Vector3.Distance(transform.position, other.transform.position);
            scannedRobotEvent.Name = other.name;
            ai.OnScannedRobot(scannedRobotEvent);
        }
    }

    public IEnumerator __Ahead(float distance) {
        int numFrames = (int)(distance / (BoatSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            transform.Translate(new Vector3(0f, 0f, BoatSpeed * Time.fixedDeltaTime), Space.Self);
            Vector3 clampedPosition = Vector3.Max(Vector3.Min(transform.position, new Vector3(SeaSize, 0, SeaSize)), new Vector3(-SeaSize, 0, -SeaSize));
            transform.position = clampedPosition;

            yield return new WaitForFixedUpdate();            
        }
    }

    public IEnumerator __Back(float distance) {
        int numFrames = (int)(distance / (BoatSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            transform.Translate(new Vector3(0f, 0f, -BoatSpeed * Time.fixedDeltaTime), Space.Self);
            Vector3 clampedPosition = Vector3.Max(Vector3.Min(transform.position, new Vector3(SeaSize, 0, SeaSize)), new Vector3(-SeaSize, 0, -SeaSize));
            transform.position = clampedPosition;

            yield return new WaitForFixedUpdate();            
        }
    }

    public IEnumerator __TurnLeft(float angle) {
        int numFrames = (int)(angle / (RotationSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            transform.Rotate(0f, -RotationSpeed * Time.fixedDeltaTime, 0f);

            yield return new WaitForFixedUpdate();            
        }
    }

    public IEnumerator __TurnRight(float angle) {
        int numFrames = (int)(angle / (RotationSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            transform.Rotate(0f, RotationSpeed * Time.fixedDeltaTime, 0f);

            yield return new WaitForFixedUpdate();            
        }
    }

    public IEnumerator __DoNothing() {
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator __FireFront(float power) {
        GameObject newInstance = Instantiate(CannonBallPrefab, CannonFrontSpawnPoint.position, CannonFrontSpawnPoint.rotation);
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator __FireLeft(float power) {
        GameObject newInstance = Instantiate(CannonBallPrefab, CannonLeftSpawnPoint.position, CannonLeftSpawnPoint.rotation);
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator __FireRight(float power) {
        GameObject newInstance = Instantiate(CannonBallPrefab, CannonRightSpawnPoint.position, CannonRightSpawnPoint.rotation);
        yield return new WaitForFixedUpdate();
    }

    public void __SetColor(Color color) {
        foreach (GameObject sail in sails) {
            sail.GetComponent<MeshRenderer>().material.color = color;
        }
    }

    public IEnumerator __TurnLookoutLeft(float angle) {
        int numFrames = (int)(angle / (RotationSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            Lookout.transform.Rotate(0f, -RotationSpeed * Time.fixedDeltaTime, 0f);

            yield return new WaitForFixedUpdate();            
        }
    }

    public IEnumerator __TurnLookoutRight(float angle) {
        int numFrames = (int)(angle / (RotationSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            Lookout.transform.Rotate(0f, RotationSpeed * Time.fixedDeltaTime, 0f);

            yield return new WaitForFixedUpdate();            
        }
    }

    #region Sean's code

    #endregion


}
