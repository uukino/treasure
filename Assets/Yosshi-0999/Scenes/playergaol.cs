using UnityEngine;
using UnityEngine.SceneManagement;

public class playergaol : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("BossStage");
        }
    }
}
