using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer_Script : MonoBehaviour
{
    public Text counterText;

    public float frames = 0f, seconds = 0f, minutes = 0f;
    const int limit = 60;
    const int MIN = 0;
    int cycles = 0;
    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>() as Text;
        minutes = 4f;
        seconds = 60f;
        frames = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //frames = (int)(Time.time % 60f);
        //frames = frames + 1;
        //seconds = seconds + .015f;

        /// Ascending mode
        /*
        seconds = seconds + .020f;
        if (seconds > limit)
        {
            seconds = 0f;
            minutes = minutes + 1;
        }
        */

        /// Descending mode
        seconds = seconds - .020f;
        if (seconds < MIN)
        {
            minutes = minutes - 1;
            seconds = 59f;
            cycles++;
        }

        if (cycles == 5)
        {
            cycles++;
            Debug.Log("Time's Up!");
            SceneManager.LoadScene("TimeUp");
            //frames = 1;
        }

        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        //counterText.text = "Time's Up!";

        //counterText.text = seconds.ToString(":" + "00");
        /*
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        */
    }
}
