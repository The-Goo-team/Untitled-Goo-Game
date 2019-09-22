using System.Collections;
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
        rb.velocity = new Vector3(mouse_pos.x * speed, mouse_pos.y * speed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameManager").GetComponent<AudioScript>().blopLand();
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

    void Update()
    {
        
        
        Vector2 dir = rb.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 


    }
}
