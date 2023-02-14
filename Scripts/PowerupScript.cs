using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform powerupTransform;

    public GameObject leftPaddle;
    public GameObject rightPaddle;
    void Start()
    {
        powerupTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        powerupTransform.rotation *= (Quaternion.Euler(new Vector3(0,0,45) * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        leftPaddle.gameObject.GetComponent<PaddleControl>().bounceForce += 100;
//        rightPaddle.gameObject.GetComponent<PaddleControl>().bounceForce += 100;
        gameObject.SetActive(false);
        Debug.Log("Entered Powerup");
    }
}
