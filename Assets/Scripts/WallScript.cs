using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.name == "CannonBall(Clone)")
        {
            Destroy(other.gameObject);
            Debug.Log("hit");
        }
    }
}
