using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracerScript : MonoBehaviour
{
    private Rigidbody2D ball; // test object
    public int mouseClickedX = 0; // X position of object origin, slime containing heart, change to match input script 
    public int mouseClickedY = 0; // Y position of object origin, slime containing heart, change to match input script
    public int mouseHeldX = 10; //  X position of mouse on screen when held
    public int mouseHeldY = 10; //  Y position of mouse on screen when held

    public float startValue = 60; // number of line segments creating sine curve, lines per frame at 60 fps 


    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = new Vector2(mouseHeldX, mouseHeldY);
        Vector2 originPosition = new Vector2(mouseClickedX,mouseClickedY);

        float lineLength = (mousePosition - originPosition).magnitude; // Length of each line segment
        float delta = lineLength/startValue;
        Vector2 Dir=(originPosition -mousePosition).normalized;

        Vector2 Origin = new Vector2(0,0);
        Vector2 LinOrigin =new Vector2(0,0);

        string what = (lineLength).ToString();

        Debug.Log(what);

        
        for(int i = 1; i <= startValue; i++)
        {
            //Debug.Log(nextOrigin.ToString());// log
            Vector2 nextPosLin   = Dir*i*delta;
            Vector2 nextPosCurve = new Vector2( nextPosLin.x, Mathf.Sin((float)(i/startValue)* 90.0f * Mathf.Deg2Rad)*nextPosLin.y);
            Debug.DrawLine(Origin, nextPosCurve,Color.green);
            Debug.DrawLine(LinOrigin, nextPosLin,Color.red);

            Origin    = nextPosCurve;
            LinOrigin = nextPosLin;

        }


    }
}