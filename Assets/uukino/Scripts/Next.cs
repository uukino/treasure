using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("tobiramae");
        }
    }
}
