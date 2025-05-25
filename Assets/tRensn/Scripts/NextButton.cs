using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("button"); 
    }
}