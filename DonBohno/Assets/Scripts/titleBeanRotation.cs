using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleBeanRotation : MonoBehaviour {

    public float minRotation;
    public float maxRotation;
    private float speed;

    // Use this for initialization
    void Start () {
        speed = Random.Range(minRotation, maxRotation);
        
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
