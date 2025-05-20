using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public int count = 0; // カウント用
    public Text countText; // スコア表示
    public float time = 10.0f; // 制限時間
    public Text timeText; // タイム表示
    public int highScore = 0; // ハイスコア
    public Text highScoreText; // ハイスコア表示
    private bool isCounting = false; // 7秒待機後にカウントを開始

    public void PushButton()
    {
        if (time > 0 && isCounting) // カウント開始後のみ加算
        {
            count++;
            countText.text = "スコア:" + count;
        }
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        highScoreText.text = "ハイスコア:" + highScore;

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

            // ハイスコア更新
            if (highScore < count)
            {
                highScore = count;
                highScoreText.text = "ハイスコア:" + highScore;
                PlayerPrefs.SetInt("HIGHSCORE", highScore);
                PlayerPrefs.Save();
            }
        }
    }
}