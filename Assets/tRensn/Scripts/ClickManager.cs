using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{

    //カウント用の変数を用意
    public int count = 0;

    //テキスト型の変数を用意。スコア表示
    public Text countText;

    //float型の変数を用意
    public float time = 10.0f;

    //テキスト型の変数を用意。タイム表示
    public Text timeText;

    //ハイスコア用の変数を用意
    public int highScore = 0;

    //テキスト型の変数を用意。ハイスコア表示
    public Text highScoreText;


    //変数を増やす関数を作成
    public void PushButton()
    {
        //timeが0より上の時
        if (time >0)
        {
            //countを1ずつ増やす
            count++;

            //増えた数字をテキストで表示
            countText.text = "スコア:" + count;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // "HIGHSCORE"をキーとして、ハイスコアを取得。値がない場合は0となる
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);

        //ハイスコアをテキストで表示
        highScoreText.text = "ハイスコア:" + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        //timeが0以下の時
        if (time <= 0)
        {
            //テキストにカウントダウンの表示をする
            timeText.text = "タイム:0.00";
        }
        else
        {
            //カウントダウンさせる
            time -= Time.deltaTime;

            //テキストにカウントダウンの表示をする
            timeText.text = "タイム:" + time.ToString("f2");
        }

        //ハイスコアを超えた場合に更新
        if (highScore < count)
        {
            highScore = count;
            Debug.Log(highScore);

            //ハイスコアをテキストで表示
            highScoreText.text = "ハイスコア:" + highScore;

            //"HIGHSCORE"をキーとして、ハイスコアを保存
            PlayerPrefs.SetInt("HIGHSCORE", highScore);

            //ディスクへの書き込み
            PlayerPrefs.Save();
        }
    }
}