using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Renderer ren;
    public Material[] mat;
    private Color NewColor;
    private CompetitionManager NewShipColor;
    // Start is called before the first frame update
    void Start()
    {
        NewColor = Random.ColorHSV();
        NewSailColor("sail_front 1");
        NewSailColor("sail_middle 1");
        NewSailColor("sail_back 1");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewSailColor(string name)
    {
        ren = transform.Find("ship_light").Find(name).GetComponent<MeshRenderer>();
        mat = ren.materials;
        mat[0].color = NewColor;
    }
}
