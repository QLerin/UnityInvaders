using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour {
    private GameObject Player;
    public EnemySpawnManager esm;
    public GameManager gm;
    public GameObject bulletFab;
    private float moveSpeed;
    private float speedValue = -0.05f;
    private float health = 1;
    private float fireTime = 0;
    private float firingDelay = 2f;
    private bool start = false;
    private bool secondPhase = false;
    private bool death = false;
    private float maxMovement = 3.2F;
    private Material material;
    public Shader pasidalinimas;
    private float koef = 0;
    public Texture shipTexture;
    public Texture shipNormal;
    public Shader blyksejimas;
    private bool bossInCentre = false;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        moveSpeed = speedValue;
       
	}
	
	// Update is called once per frame
	void Update () {
        if (!start)
        {
            Starting();
        }
        else
        {
            Movement();
            SecondPhase();
            Attack1();
            Death();
            KoefCalc();
        }
	}

    private void Movement()
    {
        if (transform.position.x < -maxMovement)
        {
            moveSpeed = speedValue;
        }
        if (transform.position.x > maxMovement)
        {
            moveSpeed = -speedValue;
        }
        transform.Translate(new Vector3(moveSpeed, 0f, 0f));
    }

    private void Starting()
    {
        if (Player.transform.position.z > 140)
        {
            esm.SetBossFight(true);
            start = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bulllet")
        {
            gm.ChangeScore(10);
            gm.UpdateScore();
            health--;
        }
    }

    private void SecondPhase()
    {
        if (health < 8 && !secondPhase)
        {
            speedValue = -0.07F;
            firingDelay = 1.5f;
            esm.SetBossFight(false);
            esm.EnableAsteroids();
            secondPhase = true;
        }
    }

    private void Attack1()
    {
        fireTime -= Time.deltaTime;
        if (fireTime < 0 && !death)
        {
            Instantiate(bulletFab, transform.position + new Vector3(-0.65f, 0.45f,-0.1f), Quaternion.identity);
            Instantiate(bulletFab, transform.position + new Vector3(0.65f,  0.45f, -0.1f), Quaternion.identity);
            fireTime = firingDelay;
        }
    }
    private void Death()
    {
        if (health < 1)
        {
            maxMovement = 0f;
            speedValue = -0.02f;
            if (!death)
            {
                material = new Material(blyksejimas);
                material.SetTexture("_MainTex", shipTexture);
                gameObject.GetComponent<Renderer>().material = material;
            }
            death = true;
            if (transform.position.x < 0.2 && transform.position.x > -0.2)
            {
                bossInCentre = true;
                speedValue = 0;
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
                material = new Material(pasidalinimas);
                material.SetTexture("_MainTex", shipTexture);
                material.SetTexture("_BumpMap", shipNormal);
                material.SetFloat("_Koef", koef);
                gameObject.GetComponent<Renderer>().material = material;
                gm.bossDefeated = true;
            }
        }
    }
    private void KoefCalc()
    {
        if (death && bossInCentre)
        {
            koef += 0.0163F;
        }
    }
}
