using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Camera main;
    public GameObject player;
    private GameManager gameManager;
    public PlayerMovement pm;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        UsualMovement();
	}

	
    void UsualMovement()
    {
        float rng = 0;
        if (pm.IsPlayerDamaged() == 1)
        { 
            rng = Random.Range(-0.1f, 0.1f);
        }
        Vector3 target = player.transform.position;
        target.x = 0 + rng;
        target.y = 0;
        target.z += 2.5f;
        Vector3 newPosition = player.transform.position;
        newPosition.x = 0 - rng; ;
        newPosition.z += 1f;
        newPosition.y = 7;
        main.transform.position = newPosition;
        main.transform.LookAt(target);
    }
}
