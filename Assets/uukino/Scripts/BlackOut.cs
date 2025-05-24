using UnityEngine;

public class BlackOut : MonoBehaviour
{
    public Transform target;
    public float speed;
    void Update()
    {
        transform.position = Vector3.MoveTowards( transform.position, target.position, speed * Time.deltaTime);
    }
}
