﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTitlescreen : MonoBehaviour {

    public float speed;
    public Rigidbody rigidbody;


    // Use this for initialization
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //bullet.transform.position += direction * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);

    }
}
