using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class GameDirector : MonoBehaviour
{

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
