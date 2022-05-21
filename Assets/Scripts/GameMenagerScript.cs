using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenagerScript : MonoBehaviour
{
    public static int TownNumber = 4;

    public bool GameOver;
    // Update is called once per frame
    void Update()
    {
        if (TownNumber == 0)
        {
            GameOver = true;
        }
    }
}
