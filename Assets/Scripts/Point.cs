using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int point = 1;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 점수 증가 (게임매니저 이용)
            GameManager.IncreaseScore(point);
            // 충돌 시 오브젝트 파괴
            Destroy(gameObject);
        }
    }
}
