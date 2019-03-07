using UnityEngine;
using UnityEngine.SceneManagement;
using CommonConstans;

public class GameDirector : MonoBehaviour
{

    /// <summary>
    /// ゲームシーンに遷移
    /// </summary>
    public void MoveGameScene()
    {
        SceneManager.LoadScene(TitleName.GAME_SCENE);
    }

    /// <summary>
    /// タイトルシーンに遷移
    /// </summary>
    public void MoveTitleScene()
    {
        SceneManager.LoadScene(TitleName.TITLE_SCENE);
    }
}
