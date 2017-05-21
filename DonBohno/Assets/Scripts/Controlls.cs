using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour {

    public string playerID;
    public GameObject thePlayer;
    public GameObject shotPoint;

    public GameObject shot;
    public float fireRate;
    public ParticleSystem system1;
    public ParticleSystem system2;


    private float nextFire;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //shoot:
            if (Input.GetButton("Shoot_P" + playerID) && Time.time > nextFire)
            {
                system1.Play();
                system2.Play();
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotPoint.transform.position, thePlayer.transform.rotation);
            }        
    }
}
