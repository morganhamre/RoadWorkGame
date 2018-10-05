using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public UIHealthPanel hpanel;
    static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void setLives(int lives){
        while (instance.hpanel.currentLives> lives){
            instance.hpanel.UpdateHearts(lives);
        }
    }
}
