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
        SceneManager.LoadScene(SceneName.GAME_SCENE);
    }

    /// <summary>
    /// タイトルシーンに遷移
    /// </summary>
    public void MoveTitleScene()
    {
        SceneManager.LoadScene(SceneName.TITLE_SCENE);
    }
}
