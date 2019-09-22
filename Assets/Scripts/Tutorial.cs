using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float time_btwn_texts = 3f;
    private float timer = 0f;
    private bool change_text = false;
    private bool text_1 = true;
    private bool text_2 = false;
    private bool text_3 = false;


    void Update() {
        if (Input.GetMouseButtonUp(0) && text_1) {
            change_text = true;
            text_1 = false;
            text_2 = true;
            text.text = "Now use the right click to shoot the goo.";
        }
        if (Input.GetMouseButtonUp(1) && text_2 && !change_text) {
            change_text = true;
            //text_2 = false;
            text_3 = true;
            text.text = "Congrats! You got the controls down. Now get to the exit pipe to continue to the next level!";
        }
        if (text_3 && !change_text) {
            //text.text = ""
        }




        if (change_text) {
            timer += Time.deltaTime;
            if (timer >= time_btwn_texts) {
                change_text = false;
                timer = 0f;
            }
        }
    }
}
