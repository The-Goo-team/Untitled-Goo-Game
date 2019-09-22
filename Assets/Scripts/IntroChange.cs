using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroChange : MonoBehaviour
{
    public Sprite[] introSprites;
    int current;
    // Start is called before the first frame update
    void Start()
    {
        current = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if(current >= introSprites.Length) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else {
                this.GetComponent<SpriteRenderer>().sprite = introSprites[current];
                current++;
            }
        }
    }
}
