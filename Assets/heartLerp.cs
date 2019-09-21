using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartLerp : MonoBehaviour
{
    private Vector3 newPosition;
    private Vector3 goalPos;
    private float intensity;

    public Transform heart;
    // Start is called before the first frame update
    private void Awake()
    {

        intensity = (float)0.100;
        goalPos = new Vector3(0, 0, 0);

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        positionChanging();

    }

    void positionChanging()
    {
        heart.position = Vector3.Lerp(heart.position, goalPos, intensity * Time.deltaTime);
    }
}
