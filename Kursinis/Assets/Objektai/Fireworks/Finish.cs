using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {
    bool already = false;
    GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((transform.position.z - Player.transform.position.z) < 5 && !already)
        {
            gameObject.GetComponent<ParticleSystem>().Play();
            already = true;
            print("boom");
        }
        
	}
}
