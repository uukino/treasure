using UnityEngine;
using UnityEngine.UI;
public class MissIcon : MonoBehaviour
{
    private float time;
    private GameObject gameobject;
    private Image image;
    void Start()
    {
        time = 0;
        image = GetComponent<Image>();
        image.fillAmount = 0;
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            Destroy(image);
            Destroy(gameobject);
        }
        image.fillAmount += Time.deltaTime;
    }
}
