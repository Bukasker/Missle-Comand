using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject[] Rockets;

    public string sceneName;

    [SerializeField] private Texture2D _cursor;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
    private void Update()
    {

        if (sceneName == "GameScene")
        {
            Cursor.SetCursor(_cursor,new Vector2(_cursor.width/2,_cursor.height/2), CursorMode.Auto);
        }
        Rockets = GameObject.FindGameObjectsWithTag("Rocket");
    }
    public void LoadScene(string ScaneName)
    {
        GameMenagerScript.isGamePaused = false;
        GameMenagerScript.Score = 0;
        SceneManager.LoadScene(ScaneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResetScene()
    {
        GameMenagerScript.Score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public static Action onNextRound;
    public void NextRound()
    {
        GameMenagerScript.isGamePaused = false;
        GameMenagerScript.RoundTime = 0;    
        SpawnMenagerScript.spawnInterval -= SpawnMenagerScript.spawnIntervalModifier;

        for (var i = 0; i < Rockets.Length; i++)
        {
            Destroy(Rockets[i]);
        }

        onNextRound?.Invoke();
    }
}
