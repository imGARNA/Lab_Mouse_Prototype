using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battey_Rotation : MonoBehaviour
{
    public float rotate = 2.5f;
    public float delta = .25f;  // Amount to move left and right from the start point
    public float speed = 1.0f;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0f, 0f, rotate);

        Vector3 v = startPos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
