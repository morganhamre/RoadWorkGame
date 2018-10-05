using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static int levelCounter = 1;

    public void OnTriggerEnter2D(Collider2D ChangeScene)
    {
        if(ChangeScene.gameObject.CompareTag("Player")){
            Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex + 1);

        }
    }
}
