using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
    public GameObject go;
    public float value = 10;

	void Start () {
	
	}

	void Update () {
        transform.Rotate(0, value * Time.deltaTime, 0);
	}

}
