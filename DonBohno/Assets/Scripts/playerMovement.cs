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
            x = Input.GetAxis("Horizontal_P" + playerID) * Time.deltaTime * speed;
            z = Input.GetAxis("Vertical_P" + playerID) * Time.deltaTime * speed;
            if (x > 0 || z > 0)
            {
                firstPush = false;
            }
        }
        if (isGrounded)
        {
            x = Input.GetAxis("Horizontal_P" + playerID) * Time.deltaTime * speed;
            z = Input.GetAxis("Vertical_P" + playerID) * Time.deltaTime * speed;
        }
        if(x == 0 && z == 0)
        {
            x = x * -1;
            z = z * -1;
        }
        Debug.Log(x + "und" + z);
        this.transform.position = this.transform.position += new Vector3(x, 0, z);
        
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
