using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject flyingGoo;
<<<<<<< HEAD
    public Crosshair    reticle;
    public float   TotalTime=1.0f;
    float          CurrentTime=0;
    Vector2        mousePosition;
    Vector2         playerPos;
    float           lineLength;
    Vector2         Dir;
    GameObject      fly_goo;
=======
    public GameObject heart_projectile;
    public GameObject heart;
>>>>>>> 5dea35d2f700eca78add7f5d8b72a7c1f216f016

    private void Start()
    {
        reticle = FindObjectOfType<Crosshair>();
    }
    private void Update()
    {
        // throw goo
        if (Input.GetMouseButtonDown(0))
        {
            dropScore();
            Vector3 spawn_pos = this.transform.position;
<<<<<<< HEAD
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

=======
            Vector3 mouse_pos = Input.mousePosition;
            mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
            
            mouse_pos -= this.transform.position;
            mouse_pos.Normalize();
            spawn_pos += mouse_pos * 2;
            GameObject fly_goo = Instantiate(flyingGoo, spawn_pos, Quaternion.identity);
            fly_goo.GetComponent<flyingGooController>().FlyTo(mouse_pos);
        }
        // throw heart
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 spawn_pos = this.transform.position;
            Vector3 mouse_pos = Input.mousePosition;
            //FindObjectsOfTypeAll The mitochondria is the powerhouse of the cell
            mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);

            
            mouse_pos -= this.transform.position;
            mouse_pos.Normalize();
            spawn_pos += mouse_pos * 2;
            spawn_pos.y += 0.5f;
            GameObject fly_heart = Instantiate(heart_projectile, spawn_pos, Quaternion.identity);

            fly_heart.GetComponent<heartController>().original_player_refrence = this.gameObject;
            fly_heart.GetComponent<heartController>().FlyTo(mouse_pos);
            Destroy(heart.gameObject);
>>>>>>> 5dea35d2f700eca78add7f5d8b72a7c1f216f016
        }
    }

    void dropScore()
    {
        GameObject _score = GameObject.Find("Level");
        Scoring scrip = _score.GetComponent<Scoring>();
        scrip.livesleft--;
    }
}
