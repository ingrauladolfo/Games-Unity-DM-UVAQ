using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class carController : MonoBehaviour
{
    public float carSpeed;
    public float maxPos = 2.2f;
    Vector3 position;
    public uiManager ui;
    int lives = 3;
    int collision;
    bool win;
    bool lose;
    public AudioSource clip;
    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        position = transform.position;
        collision = 0;
    }

    // Update is called once per frame
    void Update()
    {
        position.x+=Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x,-2.2f,2.2f);
        transform.position = position;
        
    }
    void IsWon()
    {
        ui.scoreUpdate();
        if (ui.score == 5)
        {
            Destroy(gameObject);
            ui.gameOverActivated();
            ui.winActivated();
        }
    }
    void isLose()
    {
        ui.LivesDiscount();
        if(lives == 0 || ui.collision == 5)
        {
            Destroy(gameObject);
        }
        ui.gameOverActivated();
        ui.failActivated();
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "EnemyCar") {
            Destroy(col.gameObject);
            clip.Play();
        }
        if(lives == 0 || ui.collision == 5)
        {
            isLose();
        }
    }
}
    