using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    //private Vector3 startPosition;
    public float movementSpeed = 10f;

    public float bounceForce = 400;//the force the paddle will hit the ball with. This will increase every hit
    // Start is called before the first frame update
    void Start()
    {
        //startPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        float horizontalValue = Input.GetAxis("LeftControl");

        Vector3 force = Vector3.right * horizontalValue * movementSpeed * movementSpeed * Time.deltaTime;
        rb.AddForce(force, ForceMode.Impulse);
    }



    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"We hit {collision.gameObject.name}");

        BoxCollider bc = GetComponent<BoxCollider>();
        Bounds bounds = bc.bounds;
        float maxX = bounds.max.x;
        float minX = bounds.min.x;
        float ballLocation = collision.transform.position.x;//stores where the ball is

        float angle = 1-((ballLocation - minX) /(maxX-minX));//the angle the ball is with the paddle. This is not working correctly

        float reflectionAngle = (angle - 0.5f)*2 * 60;//scales the angle to be the correct range, and then multiplies it by 60 for degrees

        Debug.Log($"max = {maxX}, min = {minX}, ball ange = {angle}");


        Quaternion rotation = Quaternion.Euler(0f, 0f, reflectionAngle);

        Vector3 bounceDirection = rotation *Vector3.up;//we start by going up, and then add a rotation, and thats how we calculate our value
        

        Rigidbody rb = collision.rigidbody;
        rb.AddForce(bounceDirection * bounceForce, ForceMode.Force);
        //bounceForce += 20;//this way each bounce will get slightly faster
    }

    public void resetBounceForce()
    {
        bounceForce = 400;
    }
}
