using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;

    private void Start()
    {
        // �J�n���ɃQ�[���I�[�o�[�p�l����\��
        gameOverPanel.SetActive(false);
    }

    // �Q�[���I�[�o�[����
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;  // �Q�[����~
    }

    // ���X�^�[�g����
    public void RestartGame()
    {
        Time.timeScale = 1f;  // ���ԍĊJ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
