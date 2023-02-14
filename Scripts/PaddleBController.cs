using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBController : MonoBehaviour
{

    public float movementSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float horizontalValue = Input.GetAxis("RightControl");

        Vector3 force = Vector3.right * horizontalValue * movementSpeed * movementSpeed * Time.deltaTime;
        rb.AddForce(force, ForceMode.VelocityChange);


        //Transform t = GetComponent<Transform>();
        //t.position += 
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"We hit {collision.gameObject.name}");

        BoxCollider bc = GetComponent<BoxCollider>();
        Bounds bounds = bc.bounds;
        float maxX = bounds.max.x;
        float minX = bounds.min.x;
        float ballLocation = collision.transform.position.x;//stores where the ball is

        float angle = ((ballLocation - minX) / (maxX - minX));//the angle the ball is with the paddle. This is not working correctly

        float reflectionAngle = (angle - 0.5f) * 2 * 60;//scales the angle to be the correct range, and then multiplies it by 60 for degrees

        Debug.Log($"max = {maxX}, min = {minX}, ball ange = {angle}");


        Quaternion rotation = Quaternion.Euler(0f, 0f, reflectionAngle);

        Vector3 bounceDirection = rotation * Vector3.down;//we start by going up, and then add a rotation, and thats how we calculate our value


        Rigidbody rb = collision.rigidbody;
        rb.AddForce(bounceDirection * 300, ForceMode.Force);
    }
}
