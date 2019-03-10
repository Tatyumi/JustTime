using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    // サウンド名
    public static class SoundName
    {
        /// <summary>秒針の音声ファイル名</summary>
        public const string CLOCK_SE = "ClockSE";
        /// <summary>コンテニューパネル表示の音声ファイル名</summary>
        public static string CONTINUE_PANEL_SE = "ContinuePanelSE";
        /// <summary>ゲーム終了音の音声ファイル名</summary>
        public static string GAME_SET_SE = "GameSetSE";
        /// <summary>開始ボタンプッシュ音の音声ファイル名</summary>
        public static string START_BUTTON_SE = "StartButtonSE";
        /// <summary>停止ボタンプッシュ音の音声ファイル名</summary>
        public static string STOP_BUTTON_SE = "StopButtonSE";

    }

    // シーン名
    public static class SceneName
    {
        /// <summary>タイトルシーン名</summary>
        public static string TITLE_SCENE = "TitleScene";
        /// <summary>ゲームシーン名</summary>
        public static string GAME_SCENE = "GameScene";
    }
}