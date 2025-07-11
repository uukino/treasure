using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveDistance = 4f;   // 移動する距離
    [SerializeField] private float moveSpeed = 1f;      // 移動速度

    private Vector3 startPos;
    private int moveDir = 3;  // 1:右, -1:左

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // 移動処理
        transform.Translate(Vector2.right * moveSpeed * moveDir * Time.deltaTime);

        // 移動距離を超えたら方向を反転
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            moveDir *= -1;
        }
    }
}
