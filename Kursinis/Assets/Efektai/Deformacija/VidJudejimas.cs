using UnityEngine;
using System.Collections;

public class VidJudejimas : MonoBehaviour {
    float koef = 0;
    private Material material;
    public GameObject playerBody;
    public Shader _norimas;
	// Use this for initialization
	void Start () {
        material = new Material(_norimas);
	}
	
	// Update is called once per frame
	void Update () {
        koef = Mathf.Sin(Time.time);
        print(koef*5);
        material.SetFloat("_Amount", koef);
        playerBody.GetComponent<Renderer>().material = material;

	}
}
