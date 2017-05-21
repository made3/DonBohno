﻿using System.Collections;
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

    public GameObject player1, player2;
    public GameObject[] spawnPoint;
    public GameObject dummiePlayer;
	// Use this for initialization
	void Start () {
        state = GameState.inGame;
        spawnPlayer();
    }

    public void spawnPlayer()
    {
        int rng = (int)Random.Range(-10.0f, 10.0f);
        //Instantiate(player1, spawnPoint[rng].transform.position, dummiePlayer.transform.rotation);
        int tmpRnG = rng;
        rng = (int)Random.Range(0, 3);
        while (rng == tmpRnG);
        {
            rng = (int)Random.Range(0, 3);
        }
        //Instantiate(player2, spawnPoint[rng].transform.position, dummiePlayer.transform.rotation);
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
            Destroy(player1);
            Destroy(player2);
            switch(tmpWin){
                case WhoWins.NoOne: break;
                case WhoWins.P1: winRate_P1 += 1; break;
                case WhoWins.P2: winRate_P2 += 1; break;
            }
            if(winRate_P1 >= winCondition || winRate_P2 >= winCondition)
            {
                state = GameState.GameOver;
            }
        }
        if (state == GameState.GameOver)
        {

        }
    }
}