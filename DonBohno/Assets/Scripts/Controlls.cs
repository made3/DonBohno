using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour {

    public string playerID;
    public GameObject thePlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Move Input
            var x = Input.GetAxis("Horizontal_P" + playerID) * Time.deltaTime * 3.0f;
            var z = Input.GetAxis("Vertical_P" + playerID) * Time.deltaTime * 3.0f;

        //shoot:
        
            var xr = -Input.GetAxis("HorizontalRight_P" + playerID);
            var zr = -Input.GetAxis("VerticalRight_P" + playerID);
        if(xr != 0 || zr !=0)
            thePlayer.transform.LookAt(transform.position + new Vector3(-Input.GetAxis("HorizontalRight_P"+ playerID), 0, -Input.GetAxis("VerticalRight_P" + playerID))); //thePlayer.transform.LookAt(new Vector3(xr,0,zr));


        //Debug.Log("x:" + x); Debug.Log("y:" + z);
        Debug.Log("x:"+ xr); Debug.Log("y:" + zr);
        this.transform.Translate(x, 0, z);
        //Direction.transform.Rotate(0, PlayerRotX * 2.0f, 0); ?

    }
}
