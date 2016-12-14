using UnityEngine;
using System.Collections;

public class FrozenEnemyBehaviour : MonoBehaviour {
    public GameObject explosion;
    public Shader _norimas;
    private float speed = 2f;
    private GameManager gameManager;
    private GameObject Player;
    private PlayerMovement playerStats;

    
    private Material material;
    private bool arNaikinti = false;
    private float koef = 0;

    
	void Start () {
        Player = GameObject.Find("Player");
        playerStats = Player.GetComponent<PlayerMovement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        material = new Material(_norimas);
	}
	
	void Update () {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if((transform.position.z - Player.transform.position.z) < -50){
            Destroy(this.gameObject);
        }
        if (arNaikinti)
        {
            if (koef <= 1)
            {
                koef += 0.035f;
                material.SetFloat("_Koef", koef);
                material.SetColor("_Color", Color.red);
                GetComponent<Renderer>().material = material;
            }
            else
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(this.gameObject);
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && arNaikinti != true)
        {
            playerStats.ChangeHealth(-1);
            gameManager.ChangeLives(playerStats.GetHealth());
            gameManager.UpdateLives();
            playerStats.SetFreezeTime(5);
            arNaikinti = true;
            
        }
        else if (other.tag == "Bulllet" && arNaikinti != true)
        {
            gameManager.ChangeScore(10);
            gameManager.UpdateScore();
            arNaikinti = true;
        }
    }
}
