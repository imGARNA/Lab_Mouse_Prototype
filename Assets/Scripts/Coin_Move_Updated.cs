using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Move_Updated : MonoBehaviour
{
    public float rotation = 2.5f;
    
    public float delta = .25f;  // Amount to move left and right from the start point
    public float speed = 1.0f;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        transform.Rotate(0f, rotation, 0f);
        transform.Rotate(0f, 0f, rotation);

        Vector3 v = startPos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
