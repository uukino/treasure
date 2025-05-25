using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TitleStater : MonoBehaviour
{
    public GameObject starter;
    public Transform starter_pos;
    //public Image image;
    public AudioSource audiosource;
    public AudioClip startvoice; 
    public AudioClip title_bgm;
    void Start()
    {
        //image = GetComponent<Image>();
        audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(title_bgm);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //image.color = Color.Lerp(image.color, new Color(0,0,0,255),0.5f * Time.deltaTime);
            Instantiate(starter, starter_pos.position, starter_pos.rotation);
            audiosource.PlayOneShot(startvoice);
        }
    }
}
