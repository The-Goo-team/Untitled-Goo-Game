using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSound : MonoBehaviour
{
    public AudioClip IntroTune;
    public AudioSource gameSound;

    // Start is called before the first frame update
    void Start() {
        gameSound.clip = IntroTune;
        gameSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
