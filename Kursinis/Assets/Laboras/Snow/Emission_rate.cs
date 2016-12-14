using UnityEngine;
using System.Collections;

public class Emission_rate : MonoBehaviour {
    public float eRate;
	// Use this for initialization
	void Start () {
        eRate = 90f;
	}
	
	// Update is called once per frame
	void Update () {
        if (eRate < 500)
        {
            eRate += 0.4f;
            gameObject.GetComponent<ParticleSystem>().emissionRate = eRate;
        }
	
	}
}
