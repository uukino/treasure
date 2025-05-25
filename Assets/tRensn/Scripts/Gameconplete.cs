using UnityEngine;
using System.Collections;

public class ShowCompleteScreen : MonoBehaviour
{
    [SerializeField] private GameObject completeScreen;
    [SerializeField] private GameObject returnToTitleButton;

    void Start()
    {
        // 最初に非表示
        completeScreen.SetActive(false);
        returnToTitleButton.SetActive(false);

        // 3秒後に画面を表示
        StartCoroutine(ShowScreenAfterDelay());
    }

    private IEnumerator ShowScreenAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        completeScreen.SetActive(true);
        returnToTitleButton.SetActive(true);
    }
}
