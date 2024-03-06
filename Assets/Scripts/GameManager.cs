using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    static int playerScore = 0;

    public static void IncreaseScore(int point)
    {
        playerScore += point;
        UpdateScore();
    }

    public static void UpdateScore()
    {
        TextMeshProUGUI scoreText = GameObject.Find("UICanvas/Score").GetComponentInChildren<TextMeshProUGUI>();
        scoreText.text = playerScore.ToString();
    }
}
