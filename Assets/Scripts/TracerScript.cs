using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracerScript : MonoBehaviour
{

    Crosshair reticle;

    public int mouseClickedX = 0; // X position of object origin, slime containing heart, change to match input script 
    public int mouseClickedY = 0; // Y position of object origin, slime containing heart, change to match input script
    public int mouseHeldX = 10; //  X position of mouse on screen when held
    public int mouseHeldY = 10; //  Y position of mouse on screen when held

    public int startValue = 60; // number of line segments creating sine curve, lines per frame at 60 fps 

    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //ball = GetComponent<Rigidbody2D>();
        reticle = FindObjectOfType<Crosshair>();
        lineRenderer=GetComponent<LineRenderer>();
        lineRenderer.positionCount=(int)startValue+1;
    }

    // Update is called once per frame
        void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint( reticle.GetMousePositionOnClick());
        Vector2 originPosition = new Vector2(mouseClickedX,mouseClickedY);

        float lineLength = (mousePosition - originPosition).magnitude; // Length of each line segment
        float delta = lineLength/startValue;
        Vector2 Dir=(mousePosition-originPosition).normalized;

        Vector2 Origin = new Vector2(0,0);
        Vector2 LinOrigin =new Vector2(0,0);
        lineRenderer.SetPosition(0,Origin);
        
        for(int i = 1; i <= startValue; i++)
        {
            //Debug.Log(nextOrigin.ToString());// log
            Vector2 nextPosLin   = Dir*i*delta;
            float nextPosy=Mathf.Sin(((float)i/(float)startValue)* 180.0f * Mathf.Deg2Rad)*nextPosLin.y;
            Vector2 nextPosCurve = new Vector2( nextPosLin.x, nextPosy<0?nextPosy*-1:nextPosy);
            lineRenderer.SetPosition(i,nextPosCurve);
            //Debug.DrawLine(Origin, nextPosCurve,Color.green);
            //Debug.DrawLine(LinOrigin, nextPosLin,Color.red);

            //Origin    = nextPosCurve;
            //LinOrigin = nextPosLin;

        }


    }
}