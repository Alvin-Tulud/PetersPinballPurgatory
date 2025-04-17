using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCharacter : MonoBehaviour
{
    private Vector3 direction;
    private const float gravity = -9.81f;
    public float gravityspeed;
    public float speed;
    public float bumperforcemin;
    public float bumperforcemax;

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

    void FixedUpdate()
    {
        if (moved)
        {
            rb.linearVelocity += new Vector3(direction.x * speed, 0, direction.z * speed);
        }

        if (bumped)
        {
            float randbumperforce = UnityEngine.Random.Range(bumperforcemin, bumperforcemax);
            rb.AddExplosionForce(randbumperforce, collisionPos, 360f, 0f, ForceMode.VelocityChange);
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

    public void getMoveVector(InputAction.CallbackContext context)
    {
        if (canMove)
        {
            if (context.started)
            {
                moved = true;

                //Debug.Log("buttons being pressed");
                Vector3 readVec = new Vector3(0, 0, -context.ReadValue<Vector2>().x);
                Debug.Log(readVec);
                direction = readVec;

                Debug.Log(direction);
            }
            else if (context.canceled)
            {
                moved = false;

                direction = Vector3.zero;
            }
        }
    }
}
