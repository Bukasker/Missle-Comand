using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class RocketScript : MonoBehaviour
{
    public GameObject[] TownPrefabs;

    private float _RocketSpeed = 3f;

    public int TownIndex;
    
    private Animator _animator;

    void Start()
    {
        TownIndex = UnityEngine.Random.Range(0, TownPrefabs.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, TownPrefabs[TownIndex].transform.position, _RocketSpeed * Time.deltaTime);
        transform.up = TownPrefabs[TownIndex].transform.position - transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        foreach(var townPrefab in TownPrefabs)
        {
            if(townPrefab == collision.collider)
            {
                TownPrefabs = TownPrefabs.Where(t=>t!=townPrefab).ToArray();
            }
        }

        Destroy(gameObject);
    }
}
