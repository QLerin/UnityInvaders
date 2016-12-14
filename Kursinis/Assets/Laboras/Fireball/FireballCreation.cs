using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireballCreation : MonoBehaviour {
    public GameObject fireball;
    private float castingTime;
    public int pooledAmount = 3;
    List<GameObject> fireballs;

	void Start () {
        castingTime = -4;
        fireballs = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(fireball);
            obj.SetActive(false);
            fireballs.Add(obj);
        }
	
	}

	void Update () {
        if (Input.GetKey(KeyCode.Q) && (Time.time - castingTime > 1))
        {
            Fire();
            castingTime = Time.time;
        }
        if (Input.GetKey(KeyCode.R) && (Time.time - castingTime > 1))
        {
            Fire();
            castingTime = Time.time;
        }
	}

    void Fire()
    {
        for (int i = 0; i < fireballs.Count; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                fireballs[i].transform.position = transform.position;
                fireballs[i].SetActive(true);
                break;
            }
        }
    }
}
