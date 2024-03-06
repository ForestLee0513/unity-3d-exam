using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 Offset;

    void FixedUpdate()
    {
        transform.position = target.position + Offset;
    }
}
