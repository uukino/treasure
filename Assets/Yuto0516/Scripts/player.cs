using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.EventTrigger;

public class Player : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    public float moveSpeed = 5f;

    // 入力された方向を格納する変数
    private Vector2 inputDirection;

    // 移動用のRigidbody2D
    private Rigidbody2D rigid;

    [SerializeField, Header("ジャンプ力")]
    private float jumpSpeed = 10f;
    private bool isGrounded;
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded)
        {
            return;
        }

        rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        isGrounded = false; // ジャンプしたら「空中にいる」状態にする
    }

    [SerializeField, Header("体力")]
    private int playerHP = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
        transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = null;
        }
    }

    void Start()
    {
        // PlayerのRigidbody2Dコンポーネントを取得する
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // プレイヤーが入力した方向に移動速度分の力を加える
        rigid.linearVelocity = new Vector2(inputDirection.x * moveSpeed, rigid.linearVelocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // 移動方向の入力情報を取得
        inputDirection = context.ReadValue<Vector2>();
    }
}
