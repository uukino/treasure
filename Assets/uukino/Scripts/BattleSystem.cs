using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    private bool player;
    private bool boss;
    private bool attack;
    private bool difense;
    private bool ap_manager;
    private bool dp_manager;
    private float ap;
    private float dp;
    private float player_hp;
    private float boss_hp;
    public Slider ap_slider;
    public Slider dp_slider;
    public Slider ph_slider;
    public Slider bh_slider;
    public Text todo_text;
    public Text situation_text;
    public Text player_hp_text;
    public Text boss_hp_text;
    public GameObject miss_icon;
    public Transform miss_pos;
    public GameObject hit1_icon;
    public GameObject hit2_icon;
    public GameObject hit3_icon;
    public Transform hit_pos;
    void Start()
    {
        player = true;
        boss = false;
        ap_manager = false;
        dp_manager = false;
        player_hp = 400f;
        boss_hp = 400f;
        ap = 0f;
        dp = 0f;
    }
    void Update()
    {
        ap_slider.value = ap;
        dp_slider.value = dp;
        ph_slider.value = player_hp;
        bh_slider.value = boss_hp;
        player_hp_text.text = player_hp.ToString();
        boss_hp_text.text = boss_hp.ToString();
        if (player_hp <= 0)
        {
            SceneManager.LoadScene("BossWin");
        }
        if (boss_hp <= 0)
        {
            SceneManager.LoadScene("PlayerWin");
        }
        if (ap_manager == true)
        {
            ap++;
        }
        if (dp_manager == true)
        {
            dp++;
        }
        battle_system();
    }
    private void battle_system()
    {
        if (player == true)
        {
            situation_text.text = "攻撃ターン";
            todo_text.text = "スペースキーでスタート";
            Debug.Log("プレイヤー");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ap_manager = true;
                attack = true;
            }
            if (attack == true)
            {
                todo_text.text = "Aキーで攻撃";
                if (Input.GetKeyDown(KeyCode.A))
                {
                    ap_manager = false;
                    boss_hp -= ap-50;
                    if (ap >= 0)
                    {
                        Instantiate(hit1_icon, hit_pos.position, hit_pos.rotation);
                    }
                    if (ap >= 120)
                    {
                        Instantiate(hit2_icon, hit_pos.position, hit_pos.rotation);
                    }
                    if (ap >= 140)
                    {
                        Instantiate(hit3_icon, hit_pos.position, hit_pos.rotation);
                    }
                    ap = 0f;
                    player = false;
                    boss = true;
                    attack = false;
                    Debug.Log("アタック");
                }
                if (ap > 150f)
                {
                    ap_manager = false;
                    ap = 0f;
                    Instantiate(miss_icon, miss_pos.position, miss_pos.rotation);
                    player = false;
                    boss = true;
                    attack = false;
                    Debug.Log("プレイヤー終了");
                }
            }
            
        }
        if (boss == true)
        {
            situation_text.text = "防御ターン";
            todo_text.text = "スペースキーでスタート";
            Debug.Log("ボス");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dp_manager = true;
                difense = true;
            }
            if (difense == true)
            {
                todo_text.text = "Dキーで防御";
                if (Input.GetKeyDown(KeyCode.D))
                {
                    dp_manager = false;
                    player_hp -= 200 - dp;
                    dp = 0f;
                    boss = false;
                    player = true;
                    difense = false;
                    Debug.Log("ディフェンス");
                }
                if (dp > 150f)
                {
                    dp_manager = false;
                    player_hp -= 150;
                    dp = 0f;
                    Instantiate(miss_icon, miss_pos.position, miss_pos.rotation);
                    boss = false;
                    player = true;
                    difense = false;
                    Debug.Log("ボス終了");
                }
            }
            
        }
    }
}
