using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip HeartPlop;
    public AudioClip BlobLandClip;
    public AudioClip tubeClip;
    public AudioSource gameSound;
    // Start is called before the first frame update
    void Start()
    {
        gameSound.clip = BlobLandClip;
        tubeSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void plopHeart() {
        gameSound.clip = HeartPlop;
        gameSound.Play();
    }

    public void blopLand() {
        gameSound.clip = BlobLandClip;
        gameSound.Play();
    }

    public void tubeSound() {
        gameSound.clip = tubeClip;
        gameSound.Play();
    }
}
