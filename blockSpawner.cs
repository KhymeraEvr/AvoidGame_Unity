using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSpawner : MonoBehaviour {

    public GameObject block;
    public GameObject shieldBlock;
    public float spawnInterval;
    public float spawnTime;
    private float spawnIntervalReduction = 0.1f;
    GameManager GM;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        GM.changeDifficulty += blocksFallFaster;
        spawnInterval = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > spawnTime)
        {
            spawnTime += spawnInterval;
            float spawnRange = Camera.main.aspect * Camera.main.orthographicSize;
            float randomScale = Random.Range(0.7f, 2f);
            Vector2 spawnPos = new Vector2(Random.Range(-spawnRange, spawnRange), Camera.main.orthographicSize + randomScale);
            Vector3 randomRotation = Vector3.forward * Random.Range(-15, 15) * -1;
            GameObject spawnedBlock = Instantiate(block, spawnPos, Quaternion.Euler(randomRotation));
            spawnedBlock.transform.localScale = Vector2.one * randomScale;
        }

    }

    void blocksFallFaster()
    {
         
        if(spawnInterval <= 0.2)
        {
            spawnIntervalReduction /= 2;
        }
        spawnInterval -= spawnIntervalReduction;
    }

    void spawnShieldBlock()
    {
        Instantiate(block, new Vector2(0, Camera.main.orthographicSize), Quaternion.identity);
    }
}
