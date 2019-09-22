using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    //Holds the max amount of lives for the level
    public int totalGoos;
    //Holds the current # of lives: needs to be updated by player
    [HideInInspector]public int goosLeft;

    public GooBarManager gbm;


    // Start is called before the first frame update
    void Start() {
        goosLeft = totalGoos;
    }

    // Update is called once per frame
    void Update() {
        if (goosLeft < 0) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void dropScore() {
        goosLeft--;
        gbm.UpdateBar(totalGoos, goosLeft);
    }
}
