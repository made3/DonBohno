using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThompsonTitlescreen : MonoBehaviour {

    public string playerID;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        float xr = Input.GetAxis("HorizontalRight_P" + playerID);
        float zr = Input.GetAxis("VerticalRight_P" + playerID);

        this.transform.LookAt(transform.position + new Vector3(xr, 0, -zr));

    }
}
