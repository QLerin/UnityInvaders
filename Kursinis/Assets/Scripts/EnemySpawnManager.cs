using UnityEngine;
using System.Collections;

public class EnemySpawnManager : MonoBehaviour {
    public float freq = 0.2f;
    public GameObject enemyFab;
    public GameObject enemyFab2;
    private bool bossFight = false;
    private GameObject Player;
    
    
	void Start () {
        Player = GameObject.Find("Player");
        StartCoroutine(Spawn());
        StartCoroutine(Spawn2());
	}

    IEnumerator Spawn()
    {
        while (!bossFight)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-6f,6f), 1, Player.transform.position.z+30);
            Instantiate(enemyFab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(freq);
        }
    }
    IEnumerator Spawn2()
    {
        while (!bossFight)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-6f, 6f), 1, Player.transform.position.z + 30);
            Instantiate(enemyFab2, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(freq*5);
        }
    }

    public void SetBossFight(bool value)
    {
        bossFight = value;
    }

    public void EnableAsteroids()
    {
        StartCoroutine(Spawn());
        StartCoroutine(Spawn2());
    }


}
