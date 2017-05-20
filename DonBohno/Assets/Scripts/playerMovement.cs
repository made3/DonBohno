using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float speed = 3f;
    public string playerID;
    private bool isGrounded;
    public bool firstPush = true;
    public float x;
    public float z;
    public GameObject thePlayer;
    public float groundedTime = 0.25f;
    private float tmpTime;
    private Vector3 tmpPosition;
    private GameObject tmpCollision;
    private bool wrongDirection;
    private float tmpX;
    private float tmpZ;
    public int health;


    // Use this for initialization
    void Start () {
        isGrounded = false;
        firstPush = true;
        wrongDirection = false;
        tmpTime = groundedTime;
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (firstPush)
        {
            x = Input.GetAxis("Horizontal_P" + playerID) * Time.deltaTime * speed;
            z = Input.GetAxis("Vertical_P" + playerID) * Time.deltaTime * speed;
            if (x > 0 || z > 0)
            {
                firstPush = false;
            }
        }*/


        if(health <= 0)
        {
            Debug.Log("Bin auf 0 Health");

            die();
        }

        if (isGrounded)
        {
            this.transform.position = tmpPosition;
            tmpTime -= Time.deltaTime;
            if (tmpTime <= 0)
            {
                x = Input.GetAxis("Horizontal_P" + playerID) * Time.deltaTime * speed;
                
                z = Input.GetAxis("Vertical_P" + playerID) * Time.deltaTime * speed;

                if (x == 0 && z == 0)
                {
                    //Debug.Log("IST IN 0");
                    x = -tmpX;
                    z = -tmpZ;
                }
                else if (wrongDirection)
                {
                    //Debug.Log("IST IN ´wrongCol");
                    x = x * -1;
                    z = z * -1;
                    wrongDirection = false;
                }
                tmpTime = groundedTime;
            }
        }






        // Player Rotation mit Gun:

        var xr = -Input.GetAxis("HorizontalRight_P" + playerID);
        var zr = Input.GetAxis("VerticalRight_P" + playerID);

        if (xr != 0 || zr != 0)
        {
            thePlayer.transform.LookAt(transform.position + new Vector3(xr, 0, zr));
        }



        tmpPosition = this.transform.position;
        tmpX = x;
        tmpZ = z;

        //Debug.Log(x + "und" + z);
        this.transform.position = this.transform.position += new Vector3(x, 0, z);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("walls"))
        {
            isGrounded = true;
        }else if (collision.gameObject.tag.Equals("player"))
        {
            wrongDirection = true;
        }
        else if (collision.gameObject.tag.Equals("death"))
        {
            this.health = 0;
        }
        else if (collision.gameObject.tag.Equals("bullet"))
        {
            this.health -= 10;
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.Equals(tmpCollision) || wrongDirection == false)
        {
            wrongDirection = true;
        }
        tmpCollision = collision.gameObject;

        isGrounded = false;
    }

    public void die()
    {
        Destroy(this.gameObject);
        //Application.LoadLevel("Scenes/main");
        
    }
}
