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
            // ���� ���� (���ӸŴ��� �̿�)
            GameManager.IncreaseScore(point);
            // �浹 �� ������Ʈ �ı�
            Destroy(gameObject);
        }
    }
}
