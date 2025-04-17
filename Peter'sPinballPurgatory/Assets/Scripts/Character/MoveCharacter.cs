using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    private Vector3 direction;
    private const float gravity = -9.81f;
    public float gravityspeed;
    public float speed;
    public float bumperforce;

    public bool canMove;
    public bool moved;

    Vector3 collisionPos;
    Collision collisionBumper;
    private bool bumped;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = Vector2.zero;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {   
            direction = Vector2.zero;
            /*
            if (Input.GetKey(KeyCode.W))
            {
                moved = true;
                direction.x++;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moved = true;
                direction.x--;
            }
            */
            if (Input.GetKey(KeyCode.D))
            {
                moved = true;
                direction.z--;
            }
            if (Input.GetKey(KeyCode.A))
            {
                moved = true;
                direction.z++;
            }
        }
    }

    void FixedUpdate()
    {
        if (moved)
        {
            rb.linearVelocity += new Vector3(direction.x * speed, 0, direction.z * speed);

            moved = false;
        }

        if (bumped)
        {
            rb.AddExplosionForce(bumperforce, collisionPos, 360f, 0f, ForceMode.VelocityChange);
            //rb.linearVelocity += (collisionBumper.GetContact(0).normal * bumperforce);

            bumped = false;
        }

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, gravity * gravityspeed, rb.linearVelocity.z);
        //Debug.Log(rb.linearVelocity);
    }

    public void setMove(bool move)
    {
        canMove = move;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumper"))
        {
            collisionPos = collision.transform.position;
            collisionBumper = collision;
            bumped = true;
        }
    }
}
