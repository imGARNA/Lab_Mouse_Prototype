using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Mouse_Movement : MonoBehaviour
{
    Material mat;
    public Texture Coin_Color;

    public float speed = .5f;
    public float rotation = 8f;
    public int score = 0;
    public int nuts = 0;
    public int maxNuts = 12;
    public float speedMod = 0f;
    public int lives;
    public float constant = .005f;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        updateUI();
        mat = GetComponent<MeshRenderer>().material;
        //PlayerPrefs.SetInt("score", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /// For The ROBOTIC MOUSE KEYBOARD
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-rotation, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rotation, 0f, 0f);
        }

        /// For The ROBOTIC MOUSE with joistick
        if (joystick.Vertical > 0)
        {
            transform.Translate(0f, 0f, joystick.Vertical * -speed);
        }
        if (joystick.Horizontal > 0)
        {
            transform.Rotate(joystick.Horizontal * rotation, 0f, 0f);
        }
        if (joystick.Vertical < 0)
        {
            transform.Translate(0f, 0f, joystick.Vertical * -speed);
        }
        if (joystick.Horizontal < 0)
        {
            transform.Rotate(joystick.Horizontal * rotation, 0f, 0f);
        }

        if(nuts >= 12)
        {
            GameObject.Find("Requirement").GetComponent<Text>().text = "You can now access the terminal.";
        }
    }

    /*
     * speed = (speed - score * .001);
     * */
    void OnCollisionEnter(Collision coll)
    {
        string tag = coll.collider.gameObject.tag;
        if (tag == "Coin")
        {
            Destroy(coll.collider.gameObject);
            speedMod = speedMod + 1;
            score = score + 50;
            nuts++;

            if (speed >= .17)
            {
                speed = (speed - speedMod * constant);
                print("Speed is: " + speed);
            }
            print("Score is: " + score);
            GameObject.Find("scoreUI").GetComponent<Text>().text = "Current score: > " + score;
            GameObject.Find("nutsUI").GetComponent<Text>().text = "Nuts collected: > " + nuts + "/" + maxNuts;
        }

        if (tag == "Platform")
        {
            if(nuts >= 12)
            {
                SceneManager.LoadScene("You_Win");
            }
            else
            {
                GameObject.Find("Requirement").GetComponent<Text>().text = "You need at least 12 nuts to activate the terminal.";
            }
            
        }
        
        if (tag == "Red_PowerUP")
        {
            Destroy(coll.collider.gameObject);
            //GetComponent<Renderer>().material.mainTexture = Coin_Color;
            mat.color = Color.red;
            //mat.color = Color.yellow;
            speed = .6f;
            print("Speed is: " + speed);
        }
    }

    void updateUI()
    {
        score = PlayerPrefs.GetInt("score");
        nuts = PlayerPrefs.GetInt("nuts");
        //maxNuts = PlayerPrefs.GetInt("maxNuts");
        GameObject.Find("scoreUI").GetComponent<Text>().text = "Current score: > " + score;
        GameObject.Find("nutsUI").GetComponent<Text>().text = "Nuts collected: > " + nuts;
        //GameObject.Find("maxNutsUI").GetComponent<Text>().text = "/" + maxNuts;
    }
}
