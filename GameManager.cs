using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private GameObject ball;

    [Header("UISetting")]
    [SerializeField] private Text scoreText;
    [SerializeField] private int score;
    private int startScore = 0;
    [SerializeField] private GameObject gameOverUI;


    private void Start()
    {
        BallControl.dead = false;
        score = startScore;
    }

    private void Update()
    {
        if(DialogueTrigger.dialogueTrigger.ballActive == true)
        {
            ball.SetActive(true);
        }

        if (BallControl.dead)
        {
            Invoke("GameOverUI", 1.5f);
        }
    }

    public void ScoreCount()
    {
        score++;
        scoreText.text = score.ToString();
    }

   public void GameOverUI()
    {
        gameOverUI.SetActive(true);
        
    }


}


