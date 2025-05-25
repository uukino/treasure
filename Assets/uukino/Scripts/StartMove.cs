using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMove : MonoBehaviour
{
    private float movespeed;
    private Rigidbody2D rigid;
    void Start()
    {
        movespeed = 8.0f;
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rigid.linearVelocity = Vector2.right * movespeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameScene");
        }
    }
}
