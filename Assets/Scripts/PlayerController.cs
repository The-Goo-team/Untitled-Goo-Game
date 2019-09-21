using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject flyingGoo;

    private void Update()
    {
          if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawn_pos = this.transform.position;
            spawn_pos.y += 2;
            GameObject fly_goo = Instantiate(flyingGoo, spawn_pos, Quaternion.identity);

            Vector3 mouse_pos = Input.mousePosition;
            mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);

            Vector2 target = mouse_pos;
            fly_goo.GetComponent<flyingGooController>().FlyTo(target);
        }
    }
}
