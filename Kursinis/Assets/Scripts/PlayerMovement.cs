using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public Shader _norimas;
    public Shader _padalinimas;
    public GameObject bulletFab;
    public GameObject playerBody;
    public GameManager gm;
    public Texture planeTexture;
    public Texture frozenTexture;
    public ParticleSystem snow;
    private float playerSpeed = 10.0f;
    private float playerHealth = 4f;
    private float hitTime;
    private float koef = 0;
    private Material material;
    private Material material2;
    private float isDamaged = 0;
    private float freezeTime = 0;
    private float fireTime = -4;
    private float naikinimoKoef = 0;

    

	void Start () {
        transform.position = new Vector3(0, 1, 0);
        hitTime = Time.time;
        material = new Material(_norimas);
        material.SetTexture("_MainTex", planeTexture);
        material.SetTexture("_DecalTex", frozenTexture);
        material2 = new Material(_padalinimas);
	}
	
	void Update () {
        RestartGame();
        if (playerHealth > 0)
        {
            fireTime -= Time.deltaTime;
            CalculateMovement();
            if (Input.GetKeyDown(KeyCode.Space) & fireTime < 0)
            {
                Instantiate(bulletFab, transform.position + Vector3.forward, Quaternion.identity);
                fireTime = 1;
            }
        }

        if (playerHealth <= 0)
        {
            if (naikinimoKoef <= 1)
            {
               // naikinimoKoef += 0.005f;
               // material2.SetFloat("_Koef", naikinimoKoef);
               //// material2.SetColor("_Color", Color.red);
               // playerBody.GetComponent<Renderer>().material = material2;
            }
            else
            {
                //Application.Quit();
            }
            
        }

        SetDeformationLevel();

        if ((Time.time - hitTime) > 0.5F)
        {
            isDamaged = 0;
        }

        if (freezeTime > 0)
        {

            freezeTime -= Time.deltaTime;
            snow.Play(true);
            if (freezeTime < 0)
            {
                freezeTime = 0;
            }
        }
        else
        {
            snow.emissionRate = 0;
            snow.Stop(true);
        }
	}

    void SetDeformationLevel()
    {
        if (playerHealth == 4)
        {
            koef = 1;
            playerSpeed = 8;
            material.SetFloat("_Koef", koef);
            material.SetFloat("_Koef2", GetFreezeK());
            playerBody.GetComponent<Renderer>().material = material;
        }
        if (playerHealth == 3)
        {
            koef = 2;
            playerSpeed = 6;
            material.SetFloat("_Koef", koef);
            material.SetFloat("_Koef2", GetFreezeK());
            playerBody.GetComponent<Renderer>().material = material;
        }
        if (playerHealth == 2)
        {
            koef = 3;
            playerSpeed = 4;
            material.SetFloat("_Koef", koef);
            material.SetFloat("_Koef2", GetFreezeK());
            playerBody.GetComponent<Renderer>().material = material;
        }
        if (playerHealth == 1)
        {
            koef = 4;
            playerSpeed = 2;
            material.SetFloat("_Koef", koef);
            material.SetFloat("_Koef2", GetFreezeK());
            playerBody.GetComponent<Renderer>().material = material;
        }
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);
        if (Input.GetAxis("Vertical") > 0)
       //     if(true)
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
        }
        //if(Input.GetKeyDown(KeyCode.W)){
        //    transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        //}
        if (transform.position.x > 4.2)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = 4.2F;
            transform.position = newPosition;
        }
        if (transform.position.z > 142)
        {
            Vector3 newPosition = transform.position;
            newPosition.z = 142;
            transform.position = newPosition;
        }
        else if (transform.position.x < -4.2F)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = -4.2F;
            transform.position = newPosition;
        }
    }

    public void ChangeHealth(float difference)
    {
        if ((Time.time - hitTime) > 0.5)
        {
            hitTime = Time.time;
            playerHealth += difference;
            isDamaged = 1;
        }
    }

    public void SetHealth(float hp)
    {
        playerHealth = hp;
    }

    public float IsPlayerDamaged()
    {
        return isDamaged;
    }

    public float GetHealth()
    {
        return playerHealth;
    }

    public void SetHealthToMax()
    {
        playerHealth = 5;
    }

    public void SetSpeed(float speed)
    {
        playerSpeed = speed;
    }

    public void SetFreezeTime(float time)
    {
        freezeTime = time;
    }

    public float GetFreezeK()
    {
        if (freezeTime > 5)
        {
            return 1F;
        }
        if (freezeTime > 4)
        {
            return 0.9F;
        }
        if (freezeTime > 3)
        {
            return 0.8F;
        }
        if (freezeTime <= 3)
        {
            return freezeTime/5;
        }
        return 0;
    }

    private void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerHealth = 4;
            transform.position = new Vector3(0, 1, 0);
            gm.ChangeLives(4);
            gm.UpdateLives();
            gm.SetScore(0);
            gm.UpdateScore();
        }
    }
}
