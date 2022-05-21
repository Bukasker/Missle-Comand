using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenagerScript : MonoBehaviour
{
    public GameObject RocketPrefab;

    private float spawnRangeX = 5;

    private float startDelay = 1f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRockets", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void SpawnRockets()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX),6f) ;
        Instantiate(RocketPrefab, spawnPos,RocketPrefab.transform.rotation);
    }
}
