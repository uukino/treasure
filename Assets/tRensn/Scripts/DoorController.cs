using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Button actionButton;  // UIのボタン
    public GameObject gameOverScreen;  // ゲームオーバー画面
    public GameObject clearScreen;  // クリア画面
    public Transform door;  // 扉のTransform
    public float moveSpeed = 7f;  // 扉の移動速度
    public float downSpeed = 5f;  // 扉の移動速度
    public float maxHeight = 431f;  // 扉が上がり切る高さ
    public float minHeight = -70f;  // 扉の下限
    private bool isPressing = false;  // ボタンが押されているか判定
    private float timer = 17.5f;  // 制限時間
    private bool canMoveDown = false;  // 扉が下降できるか判定
    private bool isCleared = false;

    private float lastpresstime = 0f;
    public float delaybeforeFall = 0.2f;

    void Start()
    {
        actionButton.onClick.AddListener(OnPressButton);
        gameOverScreen.SetActive(false);
        clearScreen.SetActive(false);

        actionButton.interactable = true;
        actionButton.gameObject.SetActive(true);

        actionButton.interactable = false;
        Invoke("EnableButton", 7f);

        if (door == null)
        {
            Debug.LogError("door が null です！ Inspector で正しく設定されているか確認してください。");
        }
        else
        {
            Debug.Log("ゲーム開始: 扉の初期位置 " + door.position.y);

        }

    }
    
    void Update()
        {
            Debug.Log("現在の扉の高さ: " + door.position.y);  // 扉の位置を確認

        if (isCleared) return;

        /*
        // ボタンが押されているなら扉を上げる
        if (isPressing && door.position.y < maxHeight)
        {
            //door.position += new Vector3(0, 3, 0);
            door.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
            isPressing = false;
            canMoveDown = true;
            Debug.Log("上昇");
        }*/
        /* // 押されていない＆下降可能なら扉を下げる
         if (!isPressing && door.position.y > minHeight && canMoveDown)
     {
         //door.position -= new Vector3(0, 1, 0);
         Debug.Log("下降");
         door.position -= new Vector3(0, downSpeed * Time.deltaTime, 0);
     }*/
        // 押されていない＆下降可能なら扉を下げる
        if (Time.time - lastpresstime > delaybeforeFall && door.position.y > minHeight && canMoveDown)
        {
            //door.position -= new Vector3(0, 1, 0);
            Debug.Log("下降");
            door.position -= new Vector3(0, downSpeed * Time.deltaTime, 0);
        }


        
        if (isPressing)
        {
            door.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
            isPressing = false;
            canMoveDown = true;
            Debug.Log("上昇");
        }

            // 制限時間のカウントダウン
            if (door.position.y < maxHeight)
            {
                timer -= Time.deltaTime;
            }

            // 時間切れならゲームオーバー画面を表示
            if (timer <= 0)
            {
                gameOverScreen.SetActive(true);
                actionButton.interactable = false;
                Debug.Log("ゲームオーバー: 制限時間終了");
                return;
            }
        }

        public void OnPressButton()
        {
            isPressing = true;
            lastpresstime = Time.time;
            Debug.Log("ボタンが押されました: " + isPressing);

        }

    void EnableButton()
    {
        actionButton.interactable = true;
    }

        void OnTriggerEnter(Collider other)
        {
        Debug.Log("Triggerに何かが入った: " + other.name);

        // 扉の下端が zimen に接触したら下降を停止
        if (other.CompareTag("Zimen"))
        {
            canMoveDown = false;
            door.position = new Vector3(door.position.x, minHeight, door.position.z);
            Debug.Log("扉が地面に接触: 下降停止");
        }
        // 扉の下端が tobirawaku に接触したらクリア画面を表示
        else if (other.CompareTag("Tobirawaku"))
        {
            clearScreen.SetActive(true);
            isCleared = true;
            Debug.LogError("ゲームクリア!");
            return;
        
        }
        }
    }
