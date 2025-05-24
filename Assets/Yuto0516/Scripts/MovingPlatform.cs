using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveDistance = 4f;   // �ړ����鋗��
    [SerializeField] private float moveSpeed = 1f;      // �ړ����x

    private Vector3 startPos;
    private int moveDir = 3;  // 1:�E, -1:��

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // �ړ�����
        transform.Translate(Vector2.right * moveSpeed * moveDir * Time.deltaTime);

        // �ړ������𒴂���������𔽓]
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            moveDir *= -1;
        }
    }
}
