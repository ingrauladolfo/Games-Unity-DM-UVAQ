using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    public Text scoreText;
    public Text distanceText;
    public Text wintxt;
    public RectTransform panel;
    public Text failscoreText;
    public Text livesText;
    bool gameOver;
    bool fail;
    public int score;
    public int lives;
    int distance;
    float restartDelay = 1.0f;
    bool win;
    public int collision;
    
    void Start()
    {
        lives = 3;
        gameOver = false;
        fail = false;
        win = false;
        score = 0;
        collision = 0;
        distance = 0;
        InvokeRepeating("scoreUpdate", 1.0f,0.5f);
        InvokeRepeating("distanceUpdate", 1.0f, 0.5f);
        InvokeRepeating("collisionUpdate", 1.0f, 0.5f);
        livesText.text = "Remaining lifes: " + lives;


    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Total score: " + score;
        distanceText.text = "Distance moved: " + distance;
        failscoreText.text = "Fail score: " + collision;
        livesText.text = "Remaining lifes: " + lives;
    }

    void distanceUpdate()
    {
        if(gameOver == false)
        {
            distance += 1;
        }
    }
    public void scoreUpdate()
    {
        if (gameOver == false)
        {
            score += 1;
        }
    }
    public void LivesDiscount()
    {
        if(gameOver == false)
        {
            lives -= 1;
        }
        
    }
   public void collisionUpdate()
    {
        LivesDiscount();
        if (gameOver == false)
        {
            collision += 1;
        }
        if(collision == 5 && lives == 0)
        {
            gameOverActivated();
        }
    }
    public void winActivated()
    {
        win = true;
        if (win == true)
        {
            Application.LoadLevel("win_scene");
        }
    }

    public void gameOverActivated()
    {
        gameOver = true;
    }
    public void failActivated()
    {
        fail = true;
        if(fail == true)
        {
            Application.LoadLevel("fail_scene");
        }
    }

    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
