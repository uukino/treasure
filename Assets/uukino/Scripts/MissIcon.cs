using UnityEngine;

public class MissIcon : MonoBehaviour
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
        if (time >= 2)
        {
            Destroy(gameObject);
        }
    }
}
