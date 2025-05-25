using UnityEngine;

public class DisplayEffect : MonoBehaviour
{
    private float time;
    private GameObject gameobject;
    void Start()
    {
        time = 0;
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.2)
        {
            Destroy(gameObject);
        }
    }
}
