using UnityEngine;
using System.Collections;

public class ShowStertScreen : MonoBehaviour
{
    [SerializeField] private GameObject stertScreen;
    [SerializeField] private GameObject returnminigamestertButton;

    void Start()
    {
        // 最初に非表示
        stertScreen.SetActive(false);
        returnminigamestertButton.SetActive(false);

        // 3秒後に画面を表示
        StartCoroutine(ShowScreenAfterDelay());
    }

    private IEnumerator ShowScreenAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        stertScreen.SetActive(true);
        returnminigamestertButton.SetActive(true);
    }
}
