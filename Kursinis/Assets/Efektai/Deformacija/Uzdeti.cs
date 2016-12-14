using UnityEngine;
using System.Collections;

public class Uzdeti : MonoBehaviour {
    public Shader _norimas;
    private Material material;
    private bool arNaikinti = false;
    private float koef = 0;

	// Use this for initialization
	void Start () {
       material = new Material(_norimas);
       
        
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            arNaikinti = true;
        }
        if (arNaikinti)
        {
            if (koef <= 1)
                koef += 0.03f;
            material.SetFloat("_Koef", koef);
            GetComponent<Renderer>().material = material;
        }

	}
}
