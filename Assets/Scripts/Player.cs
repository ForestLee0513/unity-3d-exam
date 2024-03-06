using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody player;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // X
        float vertical = Input.GetAxis("Vertical"); // Y

        Debug.Log(horizontal);
        Debug.Log(vertical);

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        player.velocity = direction * speed;
        transform.LookAt(transform.position + direction);
    }
}
