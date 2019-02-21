using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>開始ボタンプッシュ音</summary>
    public AudioClip StartButtonSE;
    /// <summary>ストップボタンプッシュ音</summary>
    public AudioClip StopButtonSE;
    /// <summary>秒針の音</summary>
    public AudioClip ClockSE;
    /// <summary>ゲーム終了時音</summary>
    public AudioClip GameSetSE;
    /// <summary>コンテニューパネル表示音</summary>
    public AudioClip ContinuePanelSE;
    /// <summary>全オウディオ保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> AudioDic;
    /// <summary>オウディオソース </summary>
    private new AudioSource audio;
    
    private void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
        
        // オウディオを格納
        AudioDic = new Dictionary<string, AudioClip> {
            { StartButtonSE.name, StartButtonSE },
            { StopButtonSE.name, StopButtonSE },
            { ClockSE.name, ClockSE },
            { GameSetSE.name, GameSetSE },
            { ContinuePanelSE.name, ContinuePanelSE },
        };
    }

    /// <summary>
    /// 効果音を流す
    /// </summary>
    /// <param name="seName">効果音の名前</param>
    public void PlaySE(string seName)
    {
        // 名前のチェック
        if (!AudioDic.ContainsKey(seName))
        {
            Debug.Log(seName + "という名前のSEがありません");
            return;
        }
        audio.PlayOneShot(AudioDic[seName]);
    }

    /// <summary>
    /// 効果音の停止
    /// </summary>
    public void StopSE()
    {
        audio.Stop();
    }
}
