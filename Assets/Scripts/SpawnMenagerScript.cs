using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenagerScript : MonoBehaviour
{
    public GameObject RocketPrefab;

    public UnityEngine.UI.Button nextRoundButton;

    [SerializeField] private TownsManager _townsManager;

    private float spawnRangeX = 5;

    public static float startDelay = 2f;
    public static float spawnInterval = 1.5f;
    public static float spawnIntervalModifier = .3f;

    void Start()
    {
        if (!GameMenagerScript.isGamePaused)
        {
            InvokeRepeating("SpawnRockets", startDelay, spawnInterval);
        }
    }

    private void OnEnable()
    {
        nextRoundButton.onClick.AddListener(InvokeSpawningRockets);
    }
    private void OnDisable()
    {
        nextRoundButton.onClick.RemoveListener(InvokeSpawningRockets);
    }

    private void InvokeSpawningRockets()
    {
        InvokeRepeating("SpawnRockets", startDelay, spawnInterval);
    }

    void SpawnRockets()
    {
        if (_townsManager.NotDestroyedTownsCounter == 0) return;

        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 6f);
        if (!GameMenagerScript.isGamePaused)
        {
            var instantiatedRocket = Instantiate(RocketPrefab, spawnPos, RocketPrefab.transform.rotation);
            var instantiatedRocketScript = instantiatedRocket.GetComponent<RocketScript>();
            instantiatedRocketScript.townToAim = _townsManager.GetRandomNotDestroyedTown();
            instantiatedRocketScript.OnRocketReachedTown += _townsManager.OnRocketReachedTown;
        }
    }
}
