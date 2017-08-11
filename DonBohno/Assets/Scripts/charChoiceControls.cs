using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class charChoiceControls : MonoBehaviour {

    public string playerID;
    public int playerIntID;
    int _Direction;
    int _PositionPointer;
    public GameObject[] _Charakters;
    public GameObject[] _Lights;
    float _tmptime;
    public float time;
    float lastInput;
    private bool noChange;
    public GameObject p1;
    public GameObject p2;
    public GameObject playerList;

    private int pfuschvariable = 0;

    // Use this for initialization
    void Start () {
        noChange = true;
        _tmptime = time;
	}
	
	// Update is called once per frame
	void Update () {

        if(playerID.Equals("1"))
        {
            _tmptime -= Time.deltaTime;
            
            if (Input.GetAxis("Horizontal_P" + playerID) < -0.9 && (_tmptime <= 0))
            {
                ChangeChar(-1);
                _tmptime = time;
            }
            if (Input.GetAxis("Horizontal_P" + playerID) > 0.9 && (_tmptime <= 0))
            {
                ChangeChar(1);
                _tmptime = time;
            }
            
            lastInput = Input.GetAxis("Horizontal_P" + playerID);
            
            if (Input.GetButton("Accept_P" + playerID) && noChange)
            {
                noChange = false;
                ChangePlayer();
            }
            
        }
        
        if (playerID.Equals("2"))
        {
            _tmptime -= Time.deltaTime;
            
            if (Input.GetAxis("Horizontal_P" + 1) < -0.9 && (_tmptime <= 0))
            {
                ChangeChar(-1);
                _tmptime = time;
                pfuschvariable++;
            }
            if (Input.GetAxis("Horizontal_P" + 1) > 0.9 && (_tmptime <= 0))
            {
                ChangeChar(1);
                _tmptime = time;
                pfuschvariable++;
            }
            
            lastInput = Input.GetAxis("Horizontal_P" + 1);

            if (Input.GetButton("Accept_P" + 1) && noChange)
            {
                noChange = false;
                ChangePlayer();
            }

            if(pfuschvariable >= 4)
            {
                SceneManager.LoadScene("main2");
            }

        }
        

        /*
        float xRot = -Input.GetAxis("Horizontal_P" + playerID);
        float zRot = Input.GetAxis("Vertical_P" + playerID);
        if(xRot > 0 && zRot == 0)
        {
            Debug.Log("nach links");
        }
        else if (xRot < 0 && zRot == 0)
        {
            Debug.Log("nach rechts");
        }*/
    }

    void ChangeChar(int dir){
        //_Charakters[_PositionPointer].GetComponent<>().isActive(false);
        if(_PositionPointer == 0 && dir == -1)
        {
            dir = 4;
        }
        if (_PositionPointer == 4 && dir == 1)
        {
            dir = -4;
        }
        _Lights[_PositionPointer].SetActive(false);
        _PositionPointer += dir;
        _Lights[_PositionPointer].SetActive(true);
    }
    void setFirstChar()
    {
        //_Charakters[_PositionPointer].GetComponent<>().isActive(false);
        _Lights[_PositionPointer].SetActive(false);
        _PositionPointer = 0;
        _Lights[_PositionPointer].SetActive(true);
    }

    void ChangePlayer()
    {
        playerList.GetComponent<Playerlist>().setCharakters(playerIntID, _PositionPointer);
        if(playerID != "2") { 
            playerID = "2";
            p1.SetActive(false);
            p2.SetActive(true);
            setFirstChar();
            noChange = true;
        }
        else
        {
            //SceneManager.LoadScene("main2");
        }
    }
}
