using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform Target;
    private Transform RotationX;
    public float RotationZ;

    // Start is called before the first frame update
    void Start()
    {
        Target = Camera.main.transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(-1 * Target.position.x, -1*Target.position.y, -6 * Target.position.z));



    }
}
