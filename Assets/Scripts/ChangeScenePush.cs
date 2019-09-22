using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScenePush : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("JSTONE:Entered Trigger");
        if(other.gameObject.GetComponent<heartController>() != null)
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
