using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreDisplayer : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bulletsText;
    public TextMeshProUGUI FinalscoreText;

    private void Update()
    {
        if (!GameMenagerScript.GameOver && !GameMenagerScript.isGamePaused)
        {
            scoreText.text = "Score : " + GameMenagerScript.Score;
            bulletsText.text = "Bullets: " + ShootingScript.BulletCounter;
            
        }
        else
        {
            FinalscoreText.text = "You Score : " + GameMenagerScript.Score;
        }
    }
}
