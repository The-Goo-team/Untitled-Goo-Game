using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

public AudioSource MusicSource;

public AudioSource PlayClick;

void Start(){


    MusicSource.Play();
}

   public void PlayGame(){
       
       PlayClick.Play();
        // Load next scene in queue
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

       
       
       
   }

    public void QuitGame(){
        PlayClick.Play();
        Application.Quit();
        Debug.Log("QUIT");
    }

}
