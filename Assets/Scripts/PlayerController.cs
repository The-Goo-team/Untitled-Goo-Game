using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject flyingGoo;
    public GameObject heart_projectile;
    public GameObject heart;
    public GameObject trail;
    public GameObject trailRed;
    public Transform launch_site;

    private void Update()
    {
        // throw goo
        if (Input.GetMouseButton(0)) {
            trajectSpawn();
        }
        if (Input.GetMouseButtonUp(0)) {
            GameObject.Find("Level").GetComponent<Scoring>().dropScore();
            Vector3 mouse_pos = Input.mousePosition;
            mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);

            mouse_pos -= this.transform.position;
            mouse_pos.Normalize();

            GameObject fly_goo = Instantiate(flyingGoo, launch_site.position, Quaternion.identity);
            fly_goo.GetComponent<flyingGooController>().FlyTo(mouse_pos);
        }
        // throw heart
        if (Input.GetMouseButton(1)) {
            trajectSpawnRed();
        }
        else if (Input.GetMouseButtonUp(1)) {
            Vector3 mouse_pos = Input.mousePosition;
            //FindObjectsOfTypeAll The mitochondria is the powerhouse of the cell
            mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);


            mouse_pos -= this.transform.position;
            mouse_pos.Normalize();
            GameObject fly_heart = Instantiate(heart_projectile, launch_site.position, Quaternion.identity);

            fly_heart.GetComponent<heartController>().original_player_refrence = this.gameObject;
            fly_heart.GetComponent<heartController>().FlyTo(mouse_pos);
            Destroy(heart.gameObject);
        }
    }

    void trajectSpawn() {
        Vector3 mouse_pos = Input.mousePosition;
        mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);

        mouse_pos -= this.transform.position;
        mouse_pos.Normalize();

        Vector3 velocity = new Vector3(mouse_pos.x * 16 * 8, mouse_pos.y * 16 * 8, 0.0f);
        GameObject trajectInst = Instantiate(trail, launch_site.position, Quaternion.identity);
        trajectInst.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    void trajectSpawnRed() {
        Vector3 mouse_pos = Input.mousePosition;
        mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);

        mouse_pos -= this.transform.position;
        mouse_pos.Normalize();

        Vector3 velocity = new Vector3(mouse_pos.x * 16 * 8, mouse_pos.y * 16 * 8, 0.0f);
        GameObject trajectInst = Instantiate(trailRed, launch_site.position, Quaternion.identity);
        trajectInst.GetComponent<Rigidbody2D>().velocity = velocity;
    }


}
