using UnityEngine;

public class MissIcon02 : MonoBehaviour
{
    private float time;
    void Start()
    {
        time = 0;
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            Destroy(gameObject);
        }
    }
}
