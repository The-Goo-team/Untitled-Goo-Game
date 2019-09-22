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
    public GameObject playerPrefab;

    public float time_untill_despawn;
    private float timer = 0;

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

            timer += Time.deltaTime;
            if (timer >= time_untill_despawn) {
                ResetPlayer();
            }
        }
    }

    public void ResetPlayer(){
        Transform playerParent = GameObject.Find("PlayerParent").transform;
        Instantiate(playerPrefab, original_player_refrence.transform.position, original_player_refrence.transform.rotation, playerParent);
        // destroy all children except for one
        if (playerParent.childCount > 1) {
            Destroy(playerParent.GetChild(0).gameObject);
        }
        Destroy(this.gameObject);
    }


}
