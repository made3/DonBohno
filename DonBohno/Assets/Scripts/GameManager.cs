using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState{
    startGame,
    inGame,
    roundOver,
    GameOver
}

enum WhoWins
{
    P1,
    P2,
    NoOne
}

public class GameManager : MonoBehaviour {

    GameState state;
    WhoWins tmpWin;
    public int winRate_P1;
    public int winRate_P2;
    public int winCondition;

    public GameObject Char1, Char2 ,char3 ,char4;

    public GameObject player1, player2;

    public GameObject[] spawnPoint;
    public GameObject dummiePlayer;
	// Use this for initialization
	void Start () {
        spawnPlayer();
        state = GameState.inGame;
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

    public void RoundOver()
    {
        
    }
	
	// Update is called once per frame
	void Update () {

        
        if (state == GameState.startGame)
        {
            spawnPlayer();
            //timer;
            state = GameState.inGame;
        }
        if (state == GameState.inGame) { 
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
            player2.GetComponent<Player>().die();
            player1.GetComponent<Player>().die();

            switch (tmpWin){
                case WhoWins.NoOne: break;
                case WhoWins.P1: winRate_P1 += 1; break;
                case WhoWins.P2: winRate_P2 += 1; break;
            }
            if(winRate_P1 >= winCondition || winRate_P2 >= winCondition)
            {
                state = GameState.GameOver;
            }
            else
            {
                state = GameState.startGame;
            }
        }
        if (state == GameState.GameOver)
        {
            // tmpWin Wins:
            //player1 : 10
            //player2 : 2
            Application.LoadLevel("main2");
        }
    }
}
