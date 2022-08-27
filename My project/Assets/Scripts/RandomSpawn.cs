using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    public float spawnRate = 2f;
    public float spawnDelay = 0f;
    public int Spawns = 0;
    public int maxSpawns = 15;

    public bool spawning = false;

    public GameObject Object;

    public GameObject StartButton;
    public GameObject ScoreBoard;

    public TrainingScore scoreScript;



    void Update()
    {



        if (Time.time > spawnDelay && Spawns < maxSpawns && spawning)
        {

            ScoreBoard.SetActive(true);

            Spawns++;

            StartButton.SetActive(false);

            spawnDelay = Time.time + spawnRate;

            Vector3 randomSpawnPosition = new Vector3(Random.Range(-15, 15), 0, Random.Range(-5, 5));

            GameObject ObjectGO = Instantiate(Object, transform.position + randomSpawnPosition, transform.rotation);

            scoreScript.target = ObjectGO;

            Destroy(ObjectGO, 2f);
        }

        if (Spawns >= maxSpawns && Time.time > spawnDelay)
        {

            Spawns = 0;
            spawning = false;
            StartButton.SetActive(true);
        }

    }

}
