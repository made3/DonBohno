using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditBeanRotation : MonoBehaviour {

    public float speed;
    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position != startPosition)
        {
            transform.Rotate(speed * Time.deltaTime, 0, 0);
        }
    }
}
