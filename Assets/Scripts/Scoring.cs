using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    //Holds the max amount of lives for the level
    public int TotalLives;
    //Holds the current # of lives: needs to be updated by player
    [HideInInspector]public int livesleft;


    // Start is called before the first frame update
    void Start() {
        livesleft = TotalLives;
    }

    // Update is called once per frame
    void Update() {
        if (livesleft < 0) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
