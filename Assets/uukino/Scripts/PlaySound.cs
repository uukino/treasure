using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip clip01;
    public AudioClip clip02;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(clip01);
        audiosource.PlayOneShot(clip02);
    }
}
