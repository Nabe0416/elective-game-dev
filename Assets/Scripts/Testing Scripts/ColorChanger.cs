using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Renderer ren;
    public Material[] mat;
    private Color NewColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        ren = this.GetComponent<MeshRenderer>();
        mat = ren.materials;
        mat[0].color = NewColor;
        mat[1].color = NewColor;
        mat[2].color = NewColor;
        mat[3].color = NewColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
