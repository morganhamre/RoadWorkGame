using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    public enum Status
    {
        Active,
        Inactive
    }

    [Tooltip("Panel with the menu items on them. Gets enabled and disabled.")]
    [SerializeField] GameObject UIPanel = null;

    Status status;

    void Start()
    {
        status = Status.Inactive;
        //Time.timeScale = 1;
        UIPanel.SetActive(false);
    }

    public void LoadScene(string scene){
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
