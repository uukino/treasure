using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 10f;

    private Vector2 inputDirection;
    private Rigidbody2D rigid;
    private bool isGrounded;

    private SpriteRenderer spriteRenderer;

    public void OnMove(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        // 横移動
        rigid.linearVelocity = new Vector2(inputDirection.x * moveSpeed, rigid.linearVelocity.y);

        // 向き変更（flipXで反転）
        if (inputDirection.x != 0)
        {
            spriteRenderer.flipX = inputDirection.x < 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = true;

            // 動く床なら子オブジェクト化
            if (collision.gameObject.CompareTag("MovingPlatform"))
            {
                transform.parent = collision.transform;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            FindAnyObjectByType<MainManager>()._ShowGameOverUI();
            enabled = false;
            GetComponent<PlayerInput>().enabled = false;
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            FindAnyObjectByType<MainManager>()._ShowGameClearUI();
            enabled = false;
            GetComponent<PlayerInput>().enabled = false;
        }
    }
}
