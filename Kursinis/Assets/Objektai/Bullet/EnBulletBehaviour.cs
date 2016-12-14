using UnityEngine;
using System.Collections;

public class EnBulletBehaviour : MonoBehaviour {

    GameObject Player;
    private PlayerMovement playerStats;
    private GameManager gameManager;
    private float speed = 10.0f;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        playerStats = Player.GetComponent<PlayerMovement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Invoke("Destroy", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        if ((transform.position.z - Player.transform.position.z) > 50)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerStats.ChangeHealth(-1);
            gameManager.ChangeLives(playerStats.GetHealth());
            gameManager.UpdateLives();
            Destroy(this.gameObject);

        }
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
