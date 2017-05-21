using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    //Controll var´s
    public string playerID;
    public bool isGrounded;
    public bool secondColide;
    public bool colideWithPlayer;
    public Vector3 lastVec;
    public Vector3 PlayerVec;

    private float tmpTime = 0.25f;
    private Collision lastCollision;

    //GameObjects
    public GameObject thePlayer;
    public Rigidbody theRigidbody;
    public ParticleSystem particleBlood;

    //Stats
    public int health;
    public float speed;

    // Use this for initialization
    void Start () {
        theRigidbody = this.GetComponent<Rigidbody>();
        theRigidbody.velocity = new Vector3(1 * speed, 0, 0);
        health = 10;
    }

    // Update is called once per frame
    void Update() {
        // Player Rotation mit Gun:

        float xRot = -Input.GetAxis("HorizontalRight_P" + playerID);
        float zRot = Input.GetAxis("VerticalRight_P" + playerID);
        if (xRot != 0 || zRot != 0)
        {
            thePlayer.transform.LookAt(transform.position + new Vector3(xRot, 0, zRot));
        }
        if(health <= 0)
        {
            die();
        }
    }
    //Player Move:

    public void FixedUpdate()
    {
        tmpTime -= Time.deltaTime;
        if (tmpTime <= 0) { 
            if (isGrounded && !secondColide && !colideWithPlayer)
            {
                Vector3 myVec = new Vector3(Input.GetAxis("Horizontal_P" + playerID), 0, Input.GetAxis("Vertical_P" + playerID));
                theRigidbody.velocity = myVec.normalized * speed;
                lastVec = theRigidbody.velocity;
            }
            if (!secondColide && colideWithPlayer)
            {
                theRigidbody.velocity = -lastVec;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 tmpVector;
        if ((collision.gameObject.tag.Equals("walls")) && lastCollision != collision)
        {
            isGrounded = true;
            lastCollision = collision;
            theRigidbody.velocity = new Vector3(0,0,0);
            colideWithPlayer = false;
        }
        else if (collision.gameObject.tag.Equals("player"))
        {
            theRigidbody.velocity = new Vector3(0, 0, 0);
            PlayerVec = collision.gameObject.GetComponent<playerMovement>().lastVec;
            colideWithPlayer = true;
        }
        if (collision.gameObject.tag.Equals("death"))
        {
            die();
        }
        if (collision.gameObject.tag.Equals("bullet"))
        {
            health -= 1;
            particleBlood.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
        isGrounded = false;
    }

    public void die()
    {
        Destroy(this.gameObject);
    }
}
