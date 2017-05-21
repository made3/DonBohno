using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
     GameObject _player1;
     GameObject _player2;
    public GameObject Camera;

    public GameObject masterObject;
    GameManager master;

    float p1x;
    float p1y;
    float p2x;
    float p2y;
    // Use this for initialization
    void Start()
    {
        master = masterObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _player1 = master.player1;
        _player2 = master.player2;
        if (_player1 && _player2) { 
        p1x = _player1.transform.position.x;
        p1y = _player1.transform.position.z;
        p2x = _player2.transform.position.x;
        p2y = _player2.transform.position.z;
            Debug.Log("p1x" + p1x + " p2x" + p2x + " p1z" + p1y + "p2z" + p2y);
        }


        this.transform.position = new Vector3((p1x+p2x)/2, this.transform.position.y ,(p1y+p2y)/2);
    }
}
