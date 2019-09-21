using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject flyingGoo;
    public Crosshair    reticle;
    public float   TotalTime=1.0f;
    float          CurrentTime=0;
    Vector2        mousePosition;
    Vector2         playerPos;
    float           lineLength;
    Vector2         Dir;
    GameObject      fly_goo;

    private void Start()
    {
        reticle = FindObjectOfType<Crosshair>();
    }
    private void Update()
    {
          if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawn_pos = this.transform.position;
            spawn_pos.y += 1;
            fly_goo = Instantiate(flyingGoo, spawn_pos, Quaternion.identity);
            mousePosition = Camera.main.ScreenToWorldPoint( reticle.GetMousePositionOnClick());
            playerPos = new Vector2(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y);
            lineLength = (mousePosition - playerPos).magnitude; // Length of each line segment
            Dir=(mousePosition-playerPos).normalized;
            


        }
        Vector2 Force=new Vector2(0,0);
        if(CurrentTime<TotalTime && fly_goo!=null)
        {
            CurrentTime+=Time.deltaTime;
            Vector2 nextPosLin   = playerPos+(Dir *lineLength*( CurrentTime/TotalTime));
            float nextPosy       = Mathf.Sin(((float)CurrentTime/(float)TotalTime)* 120.0f * Mathf.Deg2Rad)*nextPosLin.y+playerPos.y;
            Force=new Vector2( nextPosLin.x, nextPosy<0.0f?nextPosy*-1:nextPosy);
            fly_goo.GetComponent<Rigidbody2D>().velocity=(Force);

        }
        else{
            CurrentTime=0;
            fly_goo=null;

        }
    }
}
