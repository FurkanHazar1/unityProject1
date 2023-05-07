using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public BotMechanics bot;
    public CarMechanics playerControl;
    public Rigidbody playerRb;

    


    public GameObject[] bots;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private Animator anim;

    public float score;
    public float highScore;
    public float momentScore;
  
    void Start()
    {

        anim = GetComponent<Animator>();
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CarMechanics>();
        highScore= PlayerPrefs.GetInt("highScore");
        highScoreText.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        collisionControl();
        takeScore();
    }

    void collisionControl()
    {
        if (playerControl.isCollison == true)
        {
            bots = GameObject.FindGameObjectsWithTag("Bot");
            
            foreach (GameObject bots in bots)
            {
                bot = bots.GetComponent<BotMechanics>();
                bot.speed = 0;
                bot.stopAnim();
            }

            if (highScore < score)
            {
                highScore = score;
                PlayerPrefs.SetInt("highScore", (int)highScore);
            }
            Debug.Log("carpti");


        }
    }

    void takeScore()
    {

        momentScore= playerControl.transform.position.z;
        if (score <= momentScore)
        {
            score = momentScore;
            scoreText.text = "Score: " + (int)score;
        }
        
    }


  
}
