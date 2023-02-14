using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;
using UnityEngine.UIElements;

public class BallMotion : MonoBehaviour
{
    public float movementSpeed = 5;
    public Rigidbody rb;
    public Vector3 originalPosition;
    private AudioSource sound;
    private Vector3 lastPosition;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Vector3 startingForce = Vector3.down * 500f;
        rb.AddForce( startingForce);

        originalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z); ;
        sound = GetComponent<AudioSource>();//sets the audiosource

        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        speed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = transform.position;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        
            Vector3 movement = rb.velocity;
            movement = Vector3.Reflect(movement,collision.contacts[0].normal);

            //Quaternion changeAngle = Quaternion.Euler(0, 0, movement.);
            rb.AddForce(movement *80,ForceMode.Force );


            //adding sound
            if (collision.gameObject.tag != "Goal")
            {

                //Debug.Log("speed is " + speed);
                //sound = AudioClip.Create()
                sound.time = (float)0.945;
                sound.Play();
            }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            this.transform.position = originalPosition;

            Vector3 force;
            if (other.transform.name == "Top Trigger")
            {
                force = Vector3.up * 300;
            } else
            {
                force = Vector3.down * 300;
            }

            rb.velocity = Vector3.zero;
            rb.AddForce(force);



        }
    }
}
