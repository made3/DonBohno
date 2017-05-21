using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

enum GameState{
    startGame,
    inGame,
    roundOver,
    GameOver
}

enum WhoWins
{
    NoOne,
    P1,
    P2
}

public class GameManager : MonoBehaviour {

    GameState state;
    WhoWins tmpWin;
    public int winRate_P1;
    public int winRate_P2;
    public int winCondition;

    public Text player1health;
    public Text player2health;

    public Text playerRoundWin;
    public GameObject playerRoundWinUI;

    public Text playerGameWin;
    public GameObject playerGameWinUI;

    public GameObject tutorial;

    public GameObject Char1, Char2 ,char3 ,char4;

    public GameObject player1, player2;

    private bool showingRoundWinner;
    private bool showingGameWinner;

    public float timeAfterRound;
    private float tmpTimeAfterRound;

    public float timeTutorial;
    private float tmpTimeTutorial;

    public float timeAfterGame;
    private float tmpTimeAfterGame;

    private bool playerSpawned;

    public GameObject[] spawnPoint;
    public GameObject dummiePlayer;
	// Use this for initialization
	void Start () {
        state = GameState.startGame;
        showingRoundWinner = false;
        showingGameWinner = false;
        playerSpawned = false;
        tmpTimeAfterRound = timeAfterRound;
        tmpTimeAfterGame = timeAfterGame;
        tmpTimeTutorial = timeTutorial;
    }

    public void spawnPlayer()
    {
        int rng = (int)Random.Range(0, 3);
        player1 = Instantiate(Char1, spawnPoint[0].transform.position, dummiePlayer.transform.rotation);
        player1.GetComponent<Player>().playerID = ""+1;
        int tmpRnG = rng;
        //while (rng == tmpRnG);
        //{
           // rng = (int)Random.Range(0, 3);
            //if(rng != tmpRnG)char2
            //{
        player2 = Instantiate(Char2, spawnPoint[2].transform.position, dummiePlayer.transform.rotation);
        player2.GetComponent<Player>().playerID = ""+2;
        // }
        // }

    }

    public void RoundOver(bool show)
    {
        if (show)
        {
            if (tmpWin.Equals(WhoWins.P1))
            {
                playerRoundWin.text = "Player 1 won the round!";
            }
            else if(tmpWin.Equals(WhoWins.P2))
            {
                playerRoundWin.text = "Player 2 won the round!";
            }

            playerRoundWinUI.SetActive(true);
        }
        else
        {
            playerRoundWinUI.SetActive(false);
        }
    }

    public void GameOver(bool show)
    {
        if (show)
        {
            if (tmpWin.Equals(WhoWins.P1))
            {
                playerGameWin.text = "Player 1 won the Game!";
            }
            else if (tmpWin.Equals(WhoWins.P2))
            {
                playerGameWin.text = "Player 2 won the Game!";
            }

            playerGameWinUI.SetActive(true);
        }
        else
        {
            playerGameWinUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {

        if (state == GameState.startGame)
        {
            if (!playerSpawned)
            {
                spawnPlayer();
                playerSpawned = true;
            }

            if(player1.GetComponent<Player>().xPressed || player2.GetComponent<Player>().xPressed)
            {
                tutorial.SetActive(false);
            }

            if (!tutorial.activeSelf)
            {
                state = GameState.inGame;
            }



            /*
            if (tutorial.activeSelf)
            {

                tmpTimeTutorial -= Time.deltaTime;
                if (tmpTimeTutorial <= 0)
                {
                    tutorial.SetActive(false);
                    
                }
            }
            */


        }
        if (state == GameState.inGame) {


            player1health.text = "" + player1.GetComponent<Player>().health;
            
            
            player2health.text = "" + player1.GetComponent<Player>().health;
            

            if (player1.GetComponent<Player>().health <= 0 && player2.GetComponent<Player>().health <= 0)
            {
                tmpWin = WhoWins.NoOne;
                state = GameState.roundOver;
            }
            else if (player1.GetComponent<Player>().health <= 0)
            {
                tmpWin = WhoWins.P2;
                state = GameState.roundOver;
            }
            else if (player2.GetComponent<Player>().health <= 0)
            {
                tmpWin = WhoWins.P1;
                state = GameState.roundOver;
            }
        }
        if (state == GameState.roundOver)
        {

            if (!showingRoundWinner)
            {
                RoundOver(true);
                tmpTimeAfterRound -= Time.deltaTime;
                if(tmpTimeAfterRound <= 0)
                {
                    RoundOver(false);
                    tmpTimeAfterRound = timeAfterRound;
                    showingRoundWinner = true;
                }
                
            }
            else
            {
                player2.GetComponent<Player>().die();
                player1.GetComponent<Player>().die();

                switch (tmpWin)
                {
                    case WhoWins.NoOne: break;
                    case WhoWins.P1: winRate_P1 += 1; break;
                    case WhoWins.P2: winRate_P2 += 1; break;
                }
                if (winRate_P1 >= winCondition || winRate_P2 >= winCondition)
                {
                    state = GameState.GameOver;
                }
                else
                {
                    showingRoundWinner = false;
                    playerSpawned = false;
                    state = GameState.startGame;
                }
            }
        }
        if (state == GameState.GameOver)
        {
            GameOver(true);
            tmpTimeAfterGame -= Time.deltaTime;
            if (tmpTimeAfterGame <= 0)
            {
                GameOver(false);
                tmpTimeAfterGame = timeAfterGame;
                showingGameWinner = true;

                // tmpWin Wins:
                //player1 : 10
                //player2 : 2
                Application.LoadLevel("title");
            }

            
        }
    }
}
