using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody mRigidBody;
    public float speed;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            mRigidBody.AddForce(new Vector3(speed, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            mRigidBody.AddForce(new Vector3(-speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            mRigidBody.AddForce(new Vector3(0, 0, speed));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            mRigidBody.AddForce(new Vector3(0, 0, -speed));
        }
        mRigidBody.velocity = Vector3.ClampMagnitude(mRigidBody.velocity, maxSpeed);
    }
}
