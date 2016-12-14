using UnityEngine;
using System.Collections;

public class RotateAroundSun : MonoBehaviour {
    public GameObject sun;
    public GameObject planet;
    public float speed = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        planet.transform.RotateAround(new Vector3(sun.transform.position.x, sun.transform.position.y, sun.transform.position.z), Vector3.up, speed * Time.deltaTime);
	}
}
