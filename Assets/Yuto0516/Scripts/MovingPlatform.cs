using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveDistance = 4f;   // ˆÚ“®‚·‚é‹——£
    [SerializeField] private float moveSpeed = 1f;      // ˆÚ“®‘¬“x

    private Vector3 startPos;
    private int moveDir = 3;  // 1:‰E, -1:¶

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // ˆÚ“®ˆ—
        transform.Translate(Vector2.right * moveSpeed * moveDir * Time.deltaTime);

        // ˆÚ“®‹——£‚ð’´‚¦‚½‚ç•ûŒü‚ð”½“]
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            moveDir *= -1;
        }
    }
}
