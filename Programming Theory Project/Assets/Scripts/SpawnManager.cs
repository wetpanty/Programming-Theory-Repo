using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] powerups;
    public GameObject[] obstacleFs;
    public GameObject[] obstacleBs;
    private GameObject player;
    public float startDelay = 2;
    public float repeatRate = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating(nameof(SpawnPowerup), startDelay, repeatRate + 5);
        InvokeRepeating(nameof(SpawnObstacleF), startDelay + 1, repeatRate - 1);
        InvokeRepeating(nameof(SpawnObstacleB), startDelay - 1, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPowerup()
    {
        Vector3 spawnPos1 = new Vector3(Random.Range(-20f,20f) , 1, player.transform.position.z + Random.Range(80, 150));
        Instantiate(powerups[0], spawnPos1, powerups[0].transform.rotation);

    }

    void SpawnObstacleF()
    {
        Vector3 spawnPos1 = new Vector3(5.5f, 1, player.transform.position.z + Random.Range(150, 210));
        Vector3 spawnPos2 = new Vector3(15f, 1, player.transform.position.z + Random.Range(150, 210));
        int index1 = Random.Range(0, obstacleFs.Length);
        int index2 = Random.Range(0, obstacleFs.Length);
        Instantiate(obstacleFs[index1], spawnPos1, obstacleFs[index1].transform.rotation);
        Instantiate(obstacleFs[index2], spawnPos2, obstacleFs[index2].transform.rotation);
    }

    void SpawnObstacleB()
    {
        Vector3 spawnPos1 = new Vector3(-5.5f, 1, player.transform.position.z + Random.Range(170, 220));
        Vector3 spawnPos2 = new Vector3(-15f, 1, player.transform.position.z + Random.Range(170, 220));
        int index1 = Random.Range(0, obstacleBs.Length);
        int index2 = Random.Range(0, obstacleBs.Length);
        Instantiate(obstacleBs[index1], spawnPos1, obstacleBs[index1].transform.rotation);
        Instantiate(obstacleBs[index2], spawnPos2, obstacleBs[index2].transform.rotation);
    }
}
