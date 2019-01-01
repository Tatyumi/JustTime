using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {

        //タップされた場合
        if (Input.GetMouseButtonDown(0)) { 
            SceneManager.LoadScene("GameScene");
        }
    }
}
