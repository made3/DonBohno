using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject Camera;

    float p1x;
    float p1y;
    float p2x;
    float p2y;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(player1 && player2) { 
        p1x = player1.transform.position.x;
        p1y = player1.transform.position.z;
        p2x = player2.transform.position.x;
        p2y = player2.transform.position.z;
        }


        Camera.transform.position = new Vector3((p1x+p2x)/2,0,(p1y+p2y)/2);
    }
}
