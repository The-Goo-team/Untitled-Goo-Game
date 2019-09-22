using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.GetComponent<flyingGooController>() != null) {
            Destroy(other.gameObject);
        }
    }
}
