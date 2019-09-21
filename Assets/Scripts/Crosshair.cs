using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
//change
    Vector2 mousePosition;
    string mouseButtonClicked;

    // Start is called before the first frame update
    // Initialization
    void Start()
    {
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Crosshair image follwos mouse
        this.transform.position = Input.mousePosition;
        
        // Get input data
        mousePosition = GetMousePositionOnClick();
        mouseButtonClicked = GetMouseButtonOnClick();
        
        if (mouseButtonClicked.Equals("leftClick") || mouseButtonClicked.Equals("rightClick"))
        {
            Debug.Log(mouseButtonClicked + mousePosition);
        }
        
    }

    Vector2 GetMousePositionOnClick(){
        return Input.mousePosition;
    }

     string GetMouseButtonOnClick(){
         string button;
        if (Input.GetMouseButtonDown(0))
        {
            button = "leftClick";
        }
        else if (Input.GetMouseButtonDown(1))
        {
            button = "rightClick";
        }
        else{
            button = "none";
        }

        return button;
    }
}
