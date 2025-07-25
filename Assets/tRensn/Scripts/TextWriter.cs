using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    public UIText uitext;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Cotest");
    }
    
    // クリック待ちのコルーチン
    IEnumerator Skip()
    {
        while (uitext.playing) yield return 0;
        while (!uitext.IsClicked()) yield return 0;
    }
    
    // 文章を表示させるコルーチン
    IEnumerator Cotest()
    {
        uitext.DrawText("名前","やったー！やっとお宝を見つけたぞ！");
        yield return StartCoroutine("Skip");

    }
}