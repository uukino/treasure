using UnityEngine;
using UnityEngine.UI;

public class EndOfBoss : MonoBehaviour
{
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = 1;
    }
    void Update()
    {
        image.fillAmount -= Time.deltaTime;
    }
}
