using UnityEngine;
using System.Collections;

public class SunStuff : MonoBehaviour {
    public ParticleSystem ss;

	// Use this for initialization
	void Start () {
        Invoke("StartSS", 3f);
        //ss.Play(true);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void StarSS()
    {
        ss.Stop(true);
        ss.Play(true);
        Invoke("StartSSS", 3f);
    }
    void StarSSS()
    {
        ss.Stop(true);
        ss.Play(true);
        Invoke("StartSS", 3f);
    }

}
