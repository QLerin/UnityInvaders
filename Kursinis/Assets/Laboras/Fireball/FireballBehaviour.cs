using UnityEngine;
using System.Collections;

public class FireballBehaviour : MonoBehaviour {
    public ParticleSystem head;
    public ParticleSystem tail;
    private float speed = 3;
    private bool change = false;

	void Start () {
	
	}
	
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q) && !change)
        {
            head.Stop(true);
            tail.Stop(true);
            head.startColor = Color.blue;
            speed = 1;
            head.Play(true);
            tail.Play(true);
            tail.startColor = Color.blue;
            change = true;
        }
        if (Input.GetKey(KeyCode.R) && !change)
        {
            head.Stop(true);
            tail.Stop(true);
            head.startColor = Color.red;
            speed = 3;
            head.Play(true);
            tail.Play(true);
            tail.startColor = Color.red;
            change = true;
        }
	}

    void OnEnable()
    {
        Invoke("Destroy", 6f);
    }

    void Destroy()
    {
        change = false;
        gameObject.SetActive(false);

    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
