using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Mouse_Movement : MonoBehaviour
{
    Material mat;
    public Texture Coin_Color;

    public Slider speedBar;

    public float speed = .35f;
    private float rotation = 2f;
    //public float rotation = 6f;
    public int score = 0;
    public int nuts = 0;
    private int maxNuts = 12;
    public float speedMod = 0f;
    private float constant = .001f;
    //float emergencySpeed = .5f;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        speed = .35f;
        speedMod = 0f;
        score = 0;
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
            speedMod = speedMod + 2.5f;
            score = score + 50;
            nuts++;

            if (speed >= .17)
            {
                speed = (speed - speedMod * constant);
                //emergencySpeed = speed;
                print("Speed is: " + speed);
            }
            speedBar.value = speed;
            print("Score is: " + score);
            GameObject.Find("scoreUI").GetComponent<Text>().text = "Current score: > " + score;
            GameObject.Find("nutsUI").GetComponent<Text>().text = "Nuts collected: > " + nuts + "/" + maxNuts;
        }

        /*if (tag == "Maze")
        {
            if (speed >= .4)
            {
                speed = .1f;
            }
            else
            {
                speed = emergencySpeed;
            }
        }*/

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
            score = score*2;
            GameObject.Find("scoreUI").GetComponent<Text>().text = "Current score: > " + score;
        }
        if (tag == "Yellow_PowerUP")
        {
            Destroy(coll.collider.gameObject);
            mat.color = Color.yellow;
            speed = .35f;
            speedBar.value = speed;

            GameObject.Find("Message").GetComponent<Text>().text = "Speed Reset!";
        }
        if (tag == "Green_PowerUP")
        {

        }
        if (tag == "Purple_PowerUP")
        {
            //Riddle
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
