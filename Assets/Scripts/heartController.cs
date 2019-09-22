using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    Vector3 target_vector;
    private bool isMove = true;
    public GameObject original_player_refrence;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void FlyTo(Vector3 mouse_pos)
    {
        target_vector = mouse_pos;
        isMove = true;
        //rb.velocity = new Vector3(mouse_pos.x * speed, mouse_pos.y * speed, 0f);
    }

    private void Update() {
        if (isMove) 
        {
            rb.velocity = new Vector3(target_vector.x * speed, target_vector.y * speed, 0f);
        }
    }
}
