using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    CharacterMovement character;
    float startTimer = 3;
    public static float gameTime;
    public static bool canMove = false;
    public static int placeCounter;

    public int laps;
    public Text messageText;
    public Text timerText;
    public Text preambleText;
    public Text instructions;
    enum GameState { gameStart, gamePlaying, gameOver}
    private GameState game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameState.gameStart;
        gameTime = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        int finalPlace = 0;
        switch (game)
        {
            case GameState.gameStart:
                startTimer -= Time.deltaTime;
                timerText.text = "";
                preambleText.text = "";
                instructions.text = "";
                canMove = false;

                messageText.text = "" + (int)(startTimer + 1);

                if (startTimer < 0)
                {
                    gameTime = 0;
                    startTimer = 3;
                    messageText.text = "";
                    game = GameState.gamePlaying;
                }

                placeCounter = 0;
                break;
            case GameState.gamePlaying:
                gameTime += Time.deltaTime;
                int seconds = Mathf.RoundToInt(gameTime);

                canMove = true;

                timerText.text = string.Format("{0:D2}:{1:D2}", (seconds / 60), (seconds % 60));
                Debug.Log(CharacterMovement.finishLineCrossCount);
                if (CharacterMovement.finishLineCrossCount == laps +1)
                {
                    
                    game = GameState.gameOver;
                }
                break;
            case GameState.gameOver:
                canMove = false;
                preambleText.text = "Congratulations! You finished in place ";
                instructions.text = "Press enter to exit.";
                messageText.text = (placeCounter+1).ToString();

                break;
                

        }
    }
}
