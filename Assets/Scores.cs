using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour
{
    //Holds the max amount of lives for the level
    private int lives;
    //Holds the current # of lives: needs to be updated by player
    public int livesleft;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(livesleft < 0) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
