using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenagerScript : MonoBehaviour
{
    public GameObject RocketPrefab;
    [SerializeField] private TownsManager _townsManager;

    private float spawnRangeX = 5;

    private float startDelay = 1f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRockets", startDelay, spawnInterval);
    }

    void SpawnRockets()
    { 
        if(_townsManager.NotDestroyedTownsCounter == 0) return;

        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX),6f) ;

        var instantiatedRocket = Instantiate(RocketPrefab, spawnPos,RocketPrefab.transform.rotation);
        var instantiatedRocketScript = instantiatedRocket.GetComponent<RocketScript>();
        instantiatedRocketScript.townToAim = _townsManager.GetRandomNotDestroyedTown();

        instantiatedRocketScript.OnRocketReachedTown += _townsManager.OnRocketReachedTown;  
    }
}
