using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody body;
    [SerializeField]
    private float speed = 15;
    [SerializeField]
    private float speedLimit = 50;
    [SerializeField]
    private float jump = 420;

    private Transform cameraPosition;
    private bool canJump = false;

    private void Start()
    {
        body = transform.GetComponent<Rigidbody>();
        cameraPosition = Camera.main.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            canJump = true;
            print("Can Jump!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            canJump = false;
            print("Can NOT Jump!");
        }
    }

    void Update()
    {
        Vector3 forwardDirectionVec = new Vector3(transform.position.x - cameraPosition.position.x,
                                                  0,
                                                  transform.position.z - cameraPosition.position.z).normalized;
        Vector3 rightDirectionVec = new Vector3(forwardDirectionVec.z,
                                                0,
                                                -forwardDirectionVec.x).normalized;

        Vector3 coordinates = new Vector3(Input.GetAxisRaw("Horizontal"),
                                          0,
                                          Input.GetAxisRaw("Vertical")).normalized;
        Vector3 relativeDirectionalVec = (coordinates.x * rightDirectionVec + coordinates.z * forwardDirectionVec).normalized
                                          * Time.deltaTime * speed;
        
        body.AddForce((1 - body.velocity.magnitude / speedLimit) * relativeDirectionalVec, ForceMode.VelocityChange);

        if (Input.GetKey("space") && canJump)
        {
            body.AddForce(0, jump, 0);
        }
    }
}
