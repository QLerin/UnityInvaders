using UnityEngine;
using System.Collections;

public class MedkitBehaviour : MonoBehaviour {
    public Shader norimas;
    public GameObject playerBody;
    private PlayerMovement playerStats;
    private GameObject player;
    private Material material;
    public GameManager gm;
    public Texture planeTexture;
    public Texture frozenTexture;
    private bool paimta;
    private Vector3 startingPosition;

    void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerMovement>();
        material = new Material(norimas);
        material.SetTexture("_MainTex", planeTexture);
        material.SetTexture("_DecalTex", frozenTexture);
        startingPosition = transform.position;
    }

    void Update()
    {
        if (paimta)
        {
            material.SetFloat("_Koef2", playerStats.GetFreezeK());
            playerBody.GetComponent<Renderer>().material = material;
            if (Input.GetKeyDown(KeyCode.R))
            {

                transform.position = startingPosition;
                paimta = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerStats.SetHealthToMax();
            playerStats.SetSpeed(15);
            gm.ChangeLives(5);
            gm.UpdateLives();
            material.SetFloat("_Koef2", playerStats.GetFreezeK());

            playerBody.GetComponent<Renderer>().material = material;
            //Invoke("Destroy", 6f);
            paimta = true;
            transform.Translate(new Vector3(0, 10, 0));
        }
    }


    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
