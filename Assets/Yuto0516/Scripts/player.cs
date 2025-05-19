using UnityEngine;
using UnityEngine.InputSystem; // Å© Ç±ÇÍí«â¡ÅI

public class NewInputPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Keyboard.current.leftArrowKey.isPressed ? Vector2.left :
                    Keyboard.current.rightArrowKey.isPressed ? Vector2.right :
                    Vector2.zero;

        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

        if (Keyboard.current.upArrowKey.wasPressedThisFrame && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
