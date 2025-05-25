using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField, Header("ゲームオーバーUI")]
    private GameObject _GameOverUI;

    [SerializeField, Header("ゲームクリアUI")]
    private GameObject _GameClearUI;

    private bool _bShowUI;

    void Start()
    {
        _bShowUI = false;
    }

    public void _ShowGameOverUI()
    {
        _GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        _bShowUI = true;
    }

    public void _ShowGameClearUI()
    {
        _GameClearUI.SetActive(true);
        _bShowUI = true;
    }

    public void OnRestart(InputAction.CallbackContext context)
    {
        if (!_bShowUI || !context.performed) return;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
