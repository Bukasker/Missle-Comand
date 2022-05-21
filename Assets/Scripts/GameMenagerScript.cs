using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenagerScript : MonoBehaviour
{
    public TownsManager townsManager;

    public static int TownNumber = 4;

    public bool GameOver;

    void Update()
    {
        if(townsManager.NotDestroyedTownsCounter == 0)
        {
            GameOver = true;
        }
    }
}
