using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Controll var´s
    public string playerID;
    public bool isGrounded;
    public bool secondColide;
    public bool colideWithPlayer;
    public bool isStart;
    public Vector3 lastVec;
    public Vector3 PlayerVec;

    public float fireRate;
    private float nextFire;

    private float tmpTime = 1f;
    private float tmpTimeas = 0.25f;
    private Collision lastCollision;

    //GameObjects
    public GameObject thePlayer;
    public Rigidbody theRigidbody;
    public ParticleSystem particleBlood;
    public ParticleSystem particleShot1;
    public ParticleSystem particleShot2;

    public GameObject shot;
    public GameObject shotPoint;

    public GameObject tutorialUI;
    public bool xPressed;

    //Stats
    public int health;
    public float speed;

    // Use this for initialization
    void Start()
    {
        theRigidbody = this.GetComponent<Rigidbody>();
        isStart = true;
        xPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Player Rotation mit Gun:
       

        if (!isStart)
        {
            float xRot = -Input.GetAxis("HorizontalRight_P" + playerID);
            float zRot = Input.GetAxis("VerticalRight_P" + playerID);
            if (xRot != 0 || zRot != 0)
            {
                thePlayer.transform.LookAt(transform.position + new Vector3(xRot, 0, zRot));
            }
            if (Input.GetButton("Shoot_P" + playerID) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                particleShot1.Play();
                particleShot2.Play();
                Instantiate(shot, shotPoint.transform.position, thePlayer.transform.rotation);
            }
        }
    }
    //Player Move:

    public void FixedUpdate()
    {
        if (isStart)
        {
            if (Input.GetButton("Accept_P" + playerID))
            {
                xPressed = true;
            }
            if (xPressed) { 
                Vector3 myVec = new Vector3(Input.GetAxis("Horizontal_P" + playerID), 0, Input.GetAxis("Vertical_P" + playerID));
                theRigidbody.velocity = myVec.normalized * speed;
                lastVec = theRigidbody.velocity;
                if (theRigidbody.velocity.x != 0 && theRigidbody.velocity.z != 0) { isStart = false; }
            }
        }

        if (!isStart)
        {
            tmpTimeas -= Time.deltaTime;
            if (tmpTimeas <= 0 && !isStart)
            {
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 tmpVector;
        if ((collision.gameObject.tag.Equals("walls")) && lastCollision != collision)
        {
            isGrounded = true;
            lastCollision = collision;
            
            theRigidbody.velocity = new Vector3(0, 0, 0);
            colideWithPlayer = false;
        }
        //if (lastCollision == collision) { secondColide = true; theRigidbody.velocity = new Vector3(0, 0, 0); }
        else if (collision.gameObject.tag.Equals("player"))
        {
           
            theRigidbody.velocity = new Vector3(0, 0, 0);
            PlayerVec = collision.gameObject.GetComponent<Player>().lastVec;
            colideWithPlayer = true;
        }
        if (collision.gameObject.tag.Equals("death"))
        {
            health = 0;
        }
        if (collision.gameObject.tag.Equals("bullet"))
        {
            health -= 42;
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
