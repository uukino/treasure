using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;

    private void Start()
    {
        // 開始時にゲームオーバーパネル非表示
        gameOverPanel.SetActive(false);
    }

    // ゲームオーバー処理
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;  // ゲーム停止
    }

    // リスタート処理
    public void RestartGame()
    {
        Time.timeScale = 1f;  // 時間再開
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
