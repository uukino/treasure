using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public float time = 10.0f; // 制限時間
    public Text timeText; // タイム表示
    private bool isCounting = false; // 7秒待機後にカウントダウンを開始

    void Start()
    {
        // 7秒待機してカウントダウン開始
        StartCoroutine(WaitAndStartCountdown());
    }

    IEnumerator WaitAndStartCountdown()
    {
        yield return new WaitForSeconds(7.0f);
        isCounting = true;
    }

    void Update()
    {
        if (isCounting) // 7秒後にカウントダウンを開始
        {
            if (time <= 0)
            {
                timeText.text = "タイム:0.00";
            }
            else
            {
                time -= Time.deltaTime;
                timeText.text = "タイム:" + time.ToString("f2");
            }
        }
    }
}