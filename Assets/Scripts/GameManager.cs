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
    static public GameObject uiCanvas;

    void Start()
    {
        uiCanvas = GameObject.Find("UICanvas");
    }

    public static void IncreaseScore(int point)
    {
        playerScore += point;
        UpdateScore();
    }

    public static void UpdateScore()
    {
        // 지금은 텍스트 하나만 있어서 이렇게 해도 문제는 없지만 여러개라면 GetComponent"s"InChildren으로 배열을 받아서
        // 이름에 따라 다른 조건 실행하도록 수정하는게 좋아보일듯.
        TextMeshProUGUI scoreText = uiCanvas.GetComponentInChildren<TextMeshProUGUI>();
        scoreText.text = playerScore.ToString();
    }
}
