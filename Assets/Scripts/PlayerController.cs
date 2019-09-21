using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject flyingGoo;
    public GameObject heart_projectile;
    public GameObject heart;

    private void Update()
    {
        // throw goo
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawn_pos = this.transform.position;
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
            mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);

            
            mouse_pos -= this.transform.position;
            mouse_pos.Normalize();
            spawn_pos += mouse_pos * 2;
            spawn_pos.y += 0.5f;
            GameObject fly_heart = Instantiate(heart_projectile, spawn_pos, Quaternion.identity);

            fly_heart.GetComponent<heartController>().original_player_refrence = this.gameObject;
            fly_heart.GetComponent<heartController>().FlyTo(mouse_pos);
            Destroy(heart.gameObject);
        }
    }
}
