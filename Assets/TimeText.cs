using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class TimeText : MonoBehaviour {

    /// <summary>オウディオソース </summary>
    private new AudioSource audio;

    /// <summary>開始ボタンプッシュ音</summary>
    public AudioClip startButtonSe;
    /// <summary>ストップボタンプッシュ音</summary>
    public AudioClip stopButtonSe;
    /// <summary>秒針の音</summary>
    public AudioClip clockSe;
    /// <summary>ゲーム終了時音</summary>
    public AudioClip gameSet;
    /// <summary>コンテニューパネル表示音</summary>
    public AudioClip continuePanelSe;

    /// <summary>指定目標時間</summary>
    private int targetTime;
    int count = 0;

    /// <summary>計測開始時間</summary>
    public float startTime;
    /// <summary>シーン移行から開始ボタンを押すまでの時間</summary>
    public float pushTime;
    /// <summary>プレイヤー1の計測時間</summary>
    public float stopTime1;
    /// <summary>プレイヤー2の計測時間</summary>
    public float stopTime2;

    /// <summary>プレイヤー1の目標時間と計測時間の差の値</summary>
    private float differenceValueP1;
    /// <summary>プレイヤー2の目標時間と計測時間の差の値</summary>
    private float differenceValueP2;

    /// <summary>目標計測時間のテキスト</summary>
    public Text targetTimeText;
    /// <summary>表示用目標計測時間のテキスト</summary>
    public Text targetTimeText_G;
    /// <summary>計測開始時間テキスト</summary>
    public Text startTimeText;
    /// <summary>プレイヤー1の計測時間テキスト</summary>
    public Text stopTime1Text;
    /// <summary>プレイヤー2の計測時間テキスト</summary>
    public Text stopTime2Text;
    /// <summary>プレイヤー１の勝敗テキスト</summary>
    public Text win1pText;
    /// <summary>プレイヤー2の勝敗テキスト</summary>
    public Text win2pText;

    /// <summary>ゲーム開始待機パネル</summary>
    public GameObject startPanel;
    /// <summary>ゲームを続けるか促すパネル</summary>
    public GameObject countinuePanel;

    /// <summary></summary>
    private bool isTapP1;
    /// <summary></summary>
    private bool isTapP2;
    /// <summary></summary>
    private bool isCheck;
    /// <summary></summary>
    private bool isBit;
    /// <summary></summary>
    private bool isEndSe;

    void Start () {
        audio = gameObject.GetComponent<AudioSource>();
        startPanel.SetActive(true);
        countinuePanel.SetActive(false);
        targetTime = UnityEngine.Random.Range(5,11);
        targetTimeText.text = "TargetTime\n"+targetTime.ToString()+"s";
        targetTimeText_G.text = targetTime.ToString()+"s";
        startTime = 0;
        stopTime1 = 0;
        stopTime2 = 0;

        stopTime1Text.enabled = false;
        stopTime2Text.enabled = false;
        startTimeText.enabled = false;
        win1pText.enabled = false;
        win2pText.enabled = false;
        targetTimeText_G.enabled = false;

        isTapP1 = false;
        isTapP2 = false;
        isCheck = true;
        isEndSe = true;

    }

    void Update () {
        //startTime += 1 * Time.deltaTime;
        startTime = Time.time - pushTime;
        startTimeText.text = startTime.ToString("f2");

        if (targetTime / 2 < startTime)
            startTimeText.enabled = false;

        if (isTapP1 == true && isTapP2 == true && isCheck == true)
        {
            audio.Stop();
            checkTime();
        }
        else if (isCheck == false)
        {
            count++;
        }

        if (count == 160)
            if (isEndSe == true)
            {
                isEndSe = false;
                audio.PlayOneShot(continuePanelSe);
                countinuePanel.SetActive(true);
            }
    }
    //audio.PlayOneShot(SceneMoveSe);

    public void timeStop(int p)
    {
        audio.PlayOneShot(stopButtonSe);
        if (p == 1 && isTapP1 == false)
        {
            stopTime1Text.enabled = true;
            stopTime1 = Time.time - pushTime;
            //stopTime1Text.text = stopTime1.ToString("f2");
            stopTime1Text.text = "STOP!";
            isTapP1 = true;

        }
        else if (p == 2 && isTapP2 == false)
        {
            stopTime2Text.enabled = true;
            stopTime2 = Time.time - pushTime;
            //stopTime2Text.text = stopTime2.ToString("f2");
            stopTime2Text.text = "STOP!";
            isTapP2 = true;
        }
    }

    public void checkTime()
    {
        audio.PlayOneShot(gameSet);

        stopTime1Text.text = stopTime1.ToString("f2");
        stopTime2Text.text = stopTime2.ToString("f2");
        Debug.Log("チェックタイム！");
        differenceValueP1 = Math.Abs(targetTime - stopTime1);
        differenceValueP2 = Math.Abs(targetTime - stopTime2);

        if(differenceValueP1 < differenceValueP2)
        {//1Pの勝利
            Debug.Log("1pのかち！");
            win1pText.enabled = true;
        }
        else if (differenceValueP1 > differenceValueP2)
        {//2Pの勝利
            Debug.Log("2pの勝ち");
            win2pText.enabled = true;
        }
        else
        {
            //Draw!
        }

        startTimeText.enabled = false;
        isCheck = false;
        //終了，もしくは再開するパネルの表示
    }

    public void pushStartButton()
    {
        audio.PlayOneShot(startButtonSe);
        audio.PlayOneShot(clockSe);

        pushTime = Time.time;
        targetTimeText_G.enabled = true;
        startTimeText.enabled = true;
        startPanel.SetActive(false);
    }

    public void countinueGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void gameEnd()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
