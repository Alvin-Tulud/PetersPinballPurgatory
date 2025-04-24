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
    private bool bumped;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = Vector2.zero;

        rb = GetComponent<Rigidbody>();

        bumped = true;
    }

    void FixedUpdate()
    {
        if (moved)
        {
            rb.linearVelocity += new Vector3(0, 0, direction.z * speed);
        }

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, gravity * gravityspeed, rb.linearVelocity.z);
        //Debug.Log(rb.linearVelocity);
    }

    public void setMove(bool move)
    {
        canMove = move;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            GameObject g = collision.gameObject;
            //Debug.Log("hit paddle");

            if (g.GetComponent<getcollhit>().getCanHit() && bumped)
            {
                StartCoroutine(bumperCooldown());
            }
        }
    }

    IEnumerator bumperCooldown()
    {
        bumped = false;

        rb.AddForce(75f, 0, 0, ForceMode.Impulse);

        yield return new WaitForSeconds(0.1f);

        bumped = true;
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
                //Debug.Log(readVec);
                direction = readVec;

                //Debug.Log(direction);
            }
            else if (context.canceled)
            {
                moved = false;

                direction = Vector3.zero;
            }
        }
    }
}
