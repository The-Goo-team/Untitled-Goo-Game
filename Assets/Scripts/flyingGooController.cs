﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingGooController : MonoBehaviour
{
    public GameObject splat;
    public float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void FlyTo(Vector3 mouse_pos)
    {
<<<<<<< HEAD
        mouse_pos -= this.transform.position;
        mouse_pos.Normalize();
        
        rb.velocity = new Vector3(mouse_pos.x * speed, (mouse_pos.y * speed), 0f);

        
=======
        rb.velocity = new Vector3(mouse_pos.x * speed, mouse_pos.y * speed, 0f);
>>>>>>> 5dea35d2f700eca78add7f5d8b72a7c1f216f016
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "platform")
        {
            float rotation = 0f;
            if (collision.name == "top")
            {
                rotation = 0f;
            }
            else if (collision.name == "left")
            {
                rotation = 90f;
            }
            else if (collision.name == "right")
            {
                rotation = -90f;
            }
            else if (collision.name == "bottom")
            {
                rotation = 180f;
            }
            GameObject _splat = Instantiate(splat, this.transform.position, Quaternion.Euler(0f, 0f, rotation));
            Destroy(this.gameObject);
        }
    }
}
