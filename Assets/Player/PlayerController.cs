using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Run,
        Jump
    }

    [Range(3f, 5f)] // �ּ� 3 �ִ� 5
    public float speed;

    public int jump;

    Rigidbody rbody;
    Animator animator;

    float horizontal;
    float vertical;

    PlayerState state;

    //public AudioClip fbxStep;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        horizontal = Input.GetAxis("Horizontal"); // X
        vertical = Input.GetAxis("Vertical"); // Y

        if (horizontal != 0 || vertical != 0)
        {
            if (Input.GetButton("Run"))
            {
                state = PlayerState.Run;
                speed = 5f;
            } else
            {
                state = PlayerState.Walk;
                speed = 3f;
            }
        }
        else
        {
            state = PlayerState.Idle;
        }

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        rbody.transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(transform.position + direction);
        OnState();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && animator.GetBool("isJump") == false)
        {
            rbody.AddForce(Vector3.up * jump, ForceMode.Impulse);
            state = PlayerState.Jump;
            OnState();   
        }

        // �� �κ��� ���߿� ����ĳ���ͷ� �ٴڿ� ������ �ߴ��ϴ� ������ ó��. + ������ ���� �ʵ��� ����ó���� ��
        if(animator.GetBool("isJump"))
        {
            Invoke(nameof(ExitJump), 1);
        }
    }

    void ExitJump()
    {
        animator.SetBool("isJump", false);
    }

    void OnState()
    {
        switch (state)
        {
            case PlayerState.Idle:
                animator.SetBool("isWalk", false);
                animator.SetBool("isRun", false);

                break;
            case PlayerState.Walk:
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", false);
                break;
            case PlayerState.Run:
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", true);
                break;
            case PlayerState.Jump:
                animator.SetBool("isJump", true);
                break;
        }
    }

}
