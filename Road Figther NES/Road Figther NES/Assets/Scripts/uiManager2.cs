using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager2 : MonoBehaviour
{
    bool pause;

    void Start()
    {
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Play()
    {
        Application.LoadLevel("game");
    }
    public void Intro()
    {
        Application.LoadLevel("intro");
    }
    public void PauseActivated()
    {
        if(pause == false)
        {
            Time.timeScale = 1;
            pause = true;
        }
        else
        {
            Time.timeScale = 0;
            pause = false;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("game"); 
    }
}
