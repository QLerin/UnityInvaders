using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    GameObject Player;
    private float speed = 30.0f;
	// Use this for initialization
	void Start () {
	     Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if ((transform.position.z - Player.transform.position.z) > 50)
        {
            Destroy(this.gameObject);
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);

        }
    }
}
