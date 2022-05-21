using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCountScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static float score;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score;
    }
}
