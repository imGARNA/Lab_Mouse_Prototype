using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyableAfterTime : MonoBehaviour
{
    private float seconds = 0f;

    // Start is called before the first frame update
    void Start()
    {
        seconds = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        seconds = seconds + .020f;
        if (seconds >= 10)
        {
            //Destroy(gameObject);
            GameObject.Find("AuthorCredit").GetComponent<Text>().text = "";
            GameObject.Find("Message").GetComponent<Text>().text = "";
            seconds = 0f;
        }
    }
}
