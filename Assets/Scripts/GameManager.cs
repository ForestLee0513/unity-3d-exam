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
        // ������ �ؽ�Ʈ �ϳ��� �־ �̷��� �ص� ������ ������ ��������� GetComponent"s"InChildren���� �迭�� �޾Ƽ�
        // �̸��� ���� �ٸ� ���� �����ϵ��� �����ϴ°� ���ƺ��ϵ�.
        TextMeshProUGUI scoreText = uiCanvas.GetComponentInChildren<TextMeshProUGUI>();
        scoreText.text = playerScore.ToString();
    }
}
