using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.EventTrigger;

public class Player : MonoBehaviour
{
    [SerializeField, Header("�ړ����x")]
    public float moveSpeed = 5f;

    // ���͂��ꂽ�������i�[����ϐ�
    private Vector2 inputDirection;

    // �ړ��p��Rigidbody2D
    private Rigidbody2D rigid;

    [SerializeField, Header("�W�����v��")]
    private float jumpSpeed = 10f;
    private bool isGrounded;
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded)
        {
            return;
        }

        rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        isGrounded = false; // �W�����v������u�󒆂ɂ���v��Ԃɂ���
    }

    [SerializeField, Header("�̗�")]
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
        // Player��Rigidbody2D�R���|�[�l���g���擾����
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // �v���C���[�����͂��������Ɉړ����x���̗͂�������
        rigid.linearVelocity = new Vector2(inputDirection.x * moveSpeed, rigid.linearVelocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // �ړ������̓��͏����擾
        inputDirection = context.ReadValue<Vector2>();
    }
}
