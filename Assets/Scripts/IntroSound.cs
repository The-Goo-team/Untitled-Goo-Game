using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSound : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioClip IntroTune;
    public AudioSource gameSound;

    // Start is called before the first frame update
    void Start() {

        musicSource = GameObject.Find("MusicSource").GetComponent<AudioSource>();


        musicSource.clip = IntroTune;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
