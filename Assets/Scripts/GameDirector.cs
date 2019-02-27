using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Common;

public class GameDirector : MonoBehaviour
{
    /// <summary>計測開始時間</summary>
    public float StartTime;
    /// <summary>シーン移行から開始ボタンを押すまでの時間</summary>
    public float PushTime;
    /// <summary>プレイヤー1の計測時間</summary>
    public float StopTimeP1;
    /// <summary>プレイヤー2の計測時間</summary>
    public float StopTimeP2;
    /// <summary>目標計測時間のテキスト</summary>
    public Text TargetTimeText;
    /// <summary>表示用目標計測時間のテキスト</summary>
    public Text TargetTimeText_G;
    /// <summary>計測開始時間テキスト</summary>
    public Text StartTimeText;
    /// <summary>プレイヤー1の計測時間テキスト</summary>
    public Text StopTime1Text;
    /// <summary>プレイヤー2の計測時間テキスト</summary>
    public Text StopTime2Text;
    /// <summary>プレイヤー１の勝敗テキスト</summary>
    public Text Win1pText;
    /// <summary>プレイヤー2の勝敗テキスト</summary>
    public Text Win2pText;
    /// <summary>ゲーム開始待機パネル</summary>
    public GameObject StartPanel;
    /// <summary>ゲームを続けるか促すパネル</summary>
    public GameObject CountinuePanel;
    /// <summary>オーディオマネージャー</summary>
    public GameObject AudioManager;

    /// <summary>プレイヤー1の目標時間と計測時間の差の値</summary>
    private float differenceValueP1;
    /// <summary>プレイヤー2の目標時間と計測時間の差の値</summary>
    private float differenceValueP2;
    /// <summary>指定目標時間</summary>
    private int targetTime;
    /// <summary>プレイヤー1がストップボタンを一度目に押したかを判別するフラグ</summary>
    private bool isTapP1;
    /// <summary>プレイヤー2がストップボタンを一度目に押したかを判別するフラグ</summary>
    private bool isTapP2;
    /// <summary></summary>
    private bool isCheck;
    /// <summary></summary>
    private bool isEndSE;
    /// <summary></summary>
    private AudioManager audioManager;

    int count = 0;

    private void Awake()
    {
        audioManager = AudioManager.GetComponent<AudioManager>();
    }

    void Start()
    {
        StartPanel.SetActive(true);
        CountinuePanel.SetActive(false);
        targetTime = UnityEngine.Random.Range(5, 11);
        TargetTimeText.text = "TargetTime\n" + targetTime.ToString() + "s";
        TargetTimeText_G.text = targetTime.ToString() + "s";
        StartTime = 0;
        StopTimeP1 = 0;
        StopTimeP2 = 0;

        StopTime1Text.enabled = false;
        StopTime2Text.enabled = false;
        StartTimeText.enabled = false;
        Win1pText.enabled = false;
        Win2pText.enabled = false;
        TargetTimeText_G.enabled = false;

        isTapP1 = false;
        isTapP2 = false;
        isCheck = true;
        isEndSE = true;

    }

    void Update()
    {
        //開始ボタンを押してからの計測時間
        StartTime = Time.time - PushTime;
        StartTimeText.text = StartTime.ToString("f2");

        //開始ボタンを押してから指定目標時間の半分に達したか判別
        if (targetTime / 2 < StartTime)
        {
            //計測時間を非表示にする
            StartTimeText.enabled = false;
        }

        //両プレイヤーがストップボタンを押したか判別
        if (isTapP1 == true && isTapP2 == true && isCheck == true)
        {
            audioManager.StopSE();
            Judge();
        }
        else if (isCheck == false)
        {
            count++;
        }

        //ゲーム終了後，一定時間たったか判別
        if (count == 160)

            //修了の効果音を流したか判別
            if (isEndSE == true)
            {
                isEndSE = false;
                audioManager.PlaySE(Constans.CONTINUE_PANEL_SE);
                CountinuePanel.SetActive(true);
            }
    }

    /// <summary>
    /// 計測開始処理
    /// </summary>
    public void StartClock()
    {
        audioManager.PlaySE(Constans.START_BUTTON_SE);
        audioManager.PlaySE(Constans.CLOCK_SE);

        PushTime = Time.time;
        TargetTimeText_G.enabled = true;
        StartTimeText.enabled = true;
        StartPanel.SetActive(false);
    }

    /// <summary>
    /// 計測終了処理
    /// </summary>
    /// <param name="p">プレイヤー</param>
    public void StopClock(int p)
    {
        //ストップボタンを押したプレイヤーと初めに押したかを判別
        if (p == 1 && isTapP1 == false)
        {
            StopTime1Text.enabled = true;
            StopTimeP1 = Time.time - PushTime;
            StopTime1Text.text = "STOP!";
            isTapP1 = true;
            audioManager.PlaySE(Constans.STOP_BUTTON_SE);

        }
        else if (p == 2 && isTapP2 == false)
        {
            StopTime2Text.enabled = true;
            StopTimeP2 = Time.time - PushTime;
            StopTime2Text.text = "STOP!";
            isTapP2 = true;
            audioManager.PlaySE(Constans.STOP_BUTTON_SE);
        }
    }

    /// <summary>
    /// 両プレイヤーの計測時間と指定目標時間を比較し，勝敗をつける
    /// </summary>
    public void Judge()
    {
        audioManager.PlaySE(Constans.GAME_SET_SE);
        StopTime1Text.text = StopTimeP1.ToString("f2");
        StopTime2Text.text = StopTimeP2.ToString("f2");

        // 目標時間と計測時間の差分を取得
        differenceValueP1 = Math.Abs(targetTime - StopTimeP1);
        differenceValueP2 = Math.Abs(targetTime - StopTimeP2);

        //どのプレイヤーが勝利したか判別
        if (differenceValueP1 < differenceValueP2)
        {
            Debug.Log("1pのかち！");
            Win1pText.enabled = true;
        }
        else if (differenceValueP1 > differenceValueP2)
        {
            Debug.Log("2pの勝ち");
            Win2pText.enabled = true;
        }
        else
        {
            //Draw!
        }

        StartTimeText.enabled = false;
        isCheck = false;
    }

    /// <summary>
    /// ゲームシーンに遷移
    /// </summary>
    public void MoveGameScene()
    {
        SceneManager.LoadScene(Constans.GAME_SCENE);
    }

    /// <summary>
    /// タイトルシーンに遷移
    /// </summary>
    public void MoveTitleScene()
    {
        SceneManager.LoadScene(Constans.TITLE_SCENE);
    }

}
