using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracerScript : MonoBehaviour
{

    Crosshair reticle;

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
        Vector2 playerPos = new Vector2(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y);

        float lineLength = (mousePosition - playerPos).magnitude; // Length of each line segment
        float delta = lineLength/startValue;
        Vector2 Dir=(mousePosition-playerPos).normalized;

        
        Vector2 LinOrigin =new Vector2(0,0);
        lineRenderer.SetPosition(0,playerPos);
        
        for(int i = 1; i <= startValue; i++)
        {
            //Debug.Log(nextOrigin.ToString());// log
            Vector2 nextPosLin   = playerPos+(Dir*i*delta);
            float nextPosy=Mathf.Sin(((float)i/(float)startValue)* 180.0f * Mathf.Deg2Rad)*nextPosLin.y+playerPos.y;
            Vector2 nextPosCurve = new Vector2( nextPosLin.x, nextPosy<0.0f?nextPosy*-1:nextPosy);
            lineRenderer.SetPosition(i,nextPosCurve);
            //Debug.DrawLine(Origin, nextPosCurve,Color.green);
            //Debug.DrawLine(LinOrigin, nextPosLin,Color.red);

            //Origin    = nextPosCurve;
            //LinOrigin = nextPosLin;

        }


    }
}