using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beanButtons : MonoBehaviour {

    public float timeBetweenPressedAndExecuted = 0.25f;
    private float tmpTime;
    private bool isCollided;
    public GameObject martinBean;
    public GameObject pascalBean;
    private Vector3 currentPosMartin;
    private Vector3 currentPosPascal;
    public float speed;

    // Use this for initialization
    void Start () {
        tmpTime = timeBetweenPressedAndExecuted;
        isCollided = false;
        currentPosMartin = martinBean.transform.position;
        currentPosPascal = pascalBean.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1 * Time.deltaTime);

        if (isCollided)
        {
            if (this.tag.Equals("startButton"))
            {
                tmpTime -= Time.deltaTime;
                if (tmpTime <= 0)
                {
                    Debug.Log("Szenenwechsel");
                }
            }

            if (this.tag.Equals("creditsButton"))
            {
                martinBean.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                pascalBean.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCollided = true;
    }

    private void OnBecameInvisible()
    {
        isCollided = false;
        martinBean.transform.position = currentPosMartin;
        pascalBean.transform.position = currentPosPascal;
    }
}
