using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour {

    public string playerID;
    public GameObject thePlayer;
    public GameObject shotPoint;
    public int Health;

    public float speed;
    public float tilt;


    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //shoot:
            if (Input.GetButton("Shoot_P" + playerID) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotPoint.transform.position, thePlayer.transform.rotation);
            }        
    }
}
