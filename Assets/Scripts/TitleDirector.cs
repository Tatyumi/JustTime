using UnityEngine;
using UnityEngine.SceneManagement;
using CommonConstans;

public class TitleDirector : MonoBehaviour
{
    
    void Update()
    {

        // 画面がタップされた場合
        if (Input.GetMouseButtonDown(0))
        {
            // ゲームシーンに移動
            SceneManager.LoadScene(TitleName.GAME_SCENE);
        }
    }
}
