using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Platform_Script : MonoBehaviour
{
    public float score = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision coll)
    {
        string tag = coll.collider.gameObject.tag;
        if (tag == "Platform")
        {
            //transform.Translate(0f, 5, 0f);
            SceneManager.LoadScene("You_Win");
            GameObject.Find("scoreUIWin").GetComponent<Text>().text = "Your score was:  \n" + score;
        }
    }
}
