using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    private bool player;
    private bool boss;
    private bool ap_manager;
    private bool dp_manager;
    private float time;
    private float ap;
    private float dp;
    private float player_hp;
    private float boss_hp;
    public Slider slider;
    public Slider ph_slider;
    public Slider bh_slider;
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
        slider.value = ap;
        slider.value = dp;
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
            ap_manager = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ap_manager = false;
                boss_hp -= ap;
                bh_slider.value = boss_hp;
                ap = 0f;
                player = false;
                boss = true;
            }
            if (ap >= 150f)
            {
                ap_manager = false;
                ap = 0f;
                player = false;
                boss = true;
            }
        }
        if (boss == true)
        {
            dp_manager = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dp_manager = false;
                player_hp -= 150-dp;
                ph_slider.value = player_hp;
                dp = 0f;
                boss = false;
                player = true;
            }
            if (ap >= 150f)
            {
                dp_manager = false;
                player_hp -= 100;
                ph_slider.value = player_hp;
                dp = 0f;
                boss = false;
                player = true;
            }  
        }
    }
}
