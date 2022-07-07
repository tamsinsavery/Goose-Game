using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float startTimer = 3;
    float gameTime;
    public static bool canMove = false; 

    public Text messageText;
    public Text timerText;
    enum GameState { gameStart, gamePlaying, gameOver}
    private GameState game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameState.gameStart;
    }

    // Update is called once per frame
    void Update()
    {
        switch (game)
        {
            case GameState.gameStart:
                startTimer -= Time.deltaTime;

                canMove = false;

                messageText.text = "" + (int)(startTimer + 1);

                if (startTimer < 0)
                {
                    gameTime = 0;
                    startTimer = 3;
                    messageText.text = "";
                    game = GameState.gamePlaying;
                }
                break;
            case GameState.gamePlaying:
                gameTime += Time.deltaTime;
                int seconds = Mathf.RoundToInt(gameTime);

                canMove = true;

                timerText.text = string.Format("{0:D2}:{1:D2}", (seconds / 60), (seconds % 60));
                break;
            case GameState.gameOver:

                break;
                

        }
    }
}
