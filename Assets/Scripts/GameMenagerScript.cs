using System.Collections;
using UnityEngine;
using TMPro;

public class GameMenagerScript : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject NextLevelScreen;

    public TownsManager townsManager;

    public static int RoundTime;

    static public bool GameOver;
    public static bool isGamePaused;

    public static int PointsForNotDestroyedTowns = 100;
    public TextMeshProUGUI TimeText;

    [SerializeField] private int RoundDuration = 15;

    public static int Score;

    private void Start()
    {
        GameOver = false;
        RoundTime = 0;
        StartCoroutine(RoundCoroutine());
        MenuScript.onNextRound += () => StartCoroutine(RoundCoroutine());
    }

    private void OnDisable()
    {
        MenuScript.onNextRound -= () => StartCoroutine(RoundCoroutine());
    }

    private void Update()
    {
        if (townsManager.NotDestroyedTownsCounter == 0)
        {
            GameOver = true;
            GameOverScreen.SetActive(true);
        }
        else
        {
            TimeText.text = "Time : " + RoundTime;
        }
        if (RoundTime == RoundDuration)
        {
            CancelInvoke("SpawnRockets");
            NextLevelScreen.SetActive(true);
            isGamePaused = true;
        }
        else
        {
            NextLevelScreen.SetActive(false);
        }
    }

    public IEnumerator RoundCoroutine()
    {
        for(var i = 0; i <= RoundDuration; i++)
        {
            if (!GameOver && !isGamePaused)
            {
                RoundTime++;
                yield return new WaitForSeconds(1);
                RoundCoroutine();
            }
        }

        AddPointForNotDestroyedTowns();
    }
    public void AddPointForNotDestroyedTowns()
    {
        Score += townsManager.NotDestroyedTownsCounter * PointsForNotDestroyedTowns;
    }

}
