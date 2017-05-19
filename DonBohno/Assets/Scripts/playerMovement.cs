using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float speed = 1f;
    private bool isGrounded;
    private bool firstPush;
    private float x;
    private float z;
    private Rigidbody rigid;

	// Use this for initialization
	void Start () {
        isGrounded = false;
        firstPush = true;
       // rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (firstPush)
        {
            x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            firstPush = false;
        }
        if (isGrounded)
        {
            x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        }
        if(x == 0 && z == 0)
        {
            x *= -1;
            z *= -1;
        }
        Debug.Log(x + " und" + z);
        this.transform.position = this.transform.position += new Vector3(x, 0, z);

        //rigid.AddForce(new Vector3(x, 0, z));
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
