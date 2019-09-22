using System.Collections;
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
            createdBody = true;
            Instantiate(gooBody, other.gameObject.transform.position, other.gameObject.transform.rotation);
            /* This code doesn't work, trying to keep the velocity, maybe come backa nd fix later
            GameObject gooBaby = gooBody.transform.Find("heart").gameObject;
            if (gooBaby == null) { Debug.Log("No child found"); }
            gooBaby.GetComponent<Rigidbody2D>().AddForce(rigBod.velocity * 100000, ForceMode2D.Impulse);
            */
            //GameObject.Find("Level").GetComponent<AudioScript>().plopHeart();

            Destroy(this.GetComponent<heartController>().original_player_refrence);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("platform")) {
             Application.LoadLevel(Application.loadedLevel);
        }
    }

    
}
