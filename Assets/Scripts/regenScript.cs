﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regenScript : MonoBehaviour
{
    //Stores the Rigidbody of the Heart
    private Rigidbody2D rigBod;
    public GameObject gooBody;
    private bool createdBody;

    // Start is called before the first frame update
    void Start()
    {
        //Getting the rigidBody
        rigBod = GetComponent<Rigidbody2D>();
        createdBody = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("npGoo") && !createdBody) {
            this.gameObject.SetActive(false);
            createdBody = true;
            Instantiate(gooBody, other.gameObject.transform.position, Quaternion.identity);
            /* This code doesn't work, trying to keep the velocity, maybe come backa nd fix later
            GameObject gooBaby = gooBody.transform.Find("heart").gameObject;
            if (gooBaby == null) { Debug.Log("No child found"); }
            gooBaby.GetComponent<Rigidbody2D>().AddForce(rigBod.velocity * 100000, ForceMode2D.Impulse);
            */
            GameObject.Find("Level").GetComponent<AudioScript>().plopHeart();
        }
        else if (other.gameObject.CompareTag("Platforms")) {
             Application.LoadLevel(Application.loadedLevel);
        }
    }

    void dropScore() {
        GameObject _score = GameObject.Find("Level");
        Scoring scrip = _score.GetComponent<Scoring>();
        scrip.livesleft--;
    }
}
