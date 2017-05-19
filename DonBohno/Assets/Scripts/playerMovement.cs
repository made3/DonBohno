using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float speed = 1f;
    public string playerID;
    private bool isGrounded;
    public bool firstPush = true;
    private float x;
    private float z;
    private Rigidbody rigid;
    public GameObject thePlayer;
    public float groundedTime = 0.25f;
    private float tmpTime;
    private Vector3 tmpPosition;


    // Use this for initialization
    void Start () {
        isGrounded = false;
        firstPush = true;
        tmpTime = groundedTime;

       // rigid = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        if (isGrounded)
        {
            this.transform.position = tmpPosition;
            tmpTime -= Time.deltaTime;
            if (tmpTime <= 0)
            {
                x = Input.GetAxis("Horizontal_P" + playerID) * Time.deltaTime * speed;
                z = Input.GetAxis("Vertical_P" + playerID) * Time.deltaTime * speed;
                tmpTime = groundedTime;
            }
        }

        if (firstPush)
        {
            if (x > 0 || z > 0)
            {
                firstPush = false;
            }
            x = Input.GetAxis("Horizontal_P" + playerID) * Time.deltaTime * speed;
            z = Input.GetAxis("Vertical_P" + playerID) * Time.deltaTime * speed;
            
        }

        if(x == 0 && z == 0 && !isGrounded)
        {
            x = x * -1;
            z = z * -1;
        }
        Debug.Log(x + "und" + z);

        var xr = -Input.GetAxis("HorizontalRight_P" + playerID);
        var zr = Input.GetAxis("VerticalRight_P" + playerID);

        if (xr != 0 || zr != 0)
        {
            thePlayer.transform.LookAt(transform.position + new Vector3(xr, 0, zr));
        }
        tmpPosition = this.transform.position;
        this.transform.position = this.transform.position += new Vector3(x, 0, z);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionStay(Collision collision)
    {


    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
