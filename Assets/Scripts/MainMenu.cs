using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Crosshair;

public class MainMenu : MonoBehaviour
{

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot;

    public AudioSource MusicSource;

    public AudioSource PlayClick;



void Start(){

    MusicSource.Play();
    hotspot = new Vector2(cursorTexture.width/2, cursorTexture.height/2);
    Cursor.SetCursor(cursorTexture, hotspot, cursorMode);
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
