using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RiddleAnswers : MonoBehaviour
{
    /*[SerializeField]
    private Image customImage;*/

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            customImage.enabled = true;
        }
        
    }*/

    public void incorectAnswer()
    {
        //lose time spent on screen
        SceneManager.LoadScene("Main_Menu");
    }
    public void corectAnswer()
    {
        //gains 1 minute, and some nuts
        SceneManager.LoadScene("You_Win");
    }
}
