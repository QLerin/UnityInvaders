using UnityEngine;
using System.Collections;

public class CameraDamaged : MonoBehaviour {
    public Texture2D red;
    
	// Use this for initialization
	void Start () {
        print("Labass");
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), red);
        print("Labas");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
