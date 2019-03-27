using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Control_Buttons : MonoBehaviour
{
    public int maxNuts = 0;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("maxNuts", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMissionMenu()
    {
        SceneManager.LoadScene("Mission_Select_Screen");
    }

    public void ExitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void EplanationScreen()
    {
        SceneManager.LoadScene("ExplanationScreen");
    }

    public void startMisison1()
    {
        //maxNuts = 14;
        SceneManager.LoadScene("Mission_1");
    }

    public void startMisison2()
    {
        //maxNuts = 20;
        //PlayerPrefs.SetInt("maxNuts", 20);
        SceneManager.LoadScene("Mission_2");
    }

    public void startMisison3()
    {
        SceneManager.LoadScene("Mission_3");
    }
}
