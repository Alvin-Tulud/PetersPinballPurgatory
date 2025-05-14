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

    private bool canLaunch;
    private bool hasLaunched;
    private bool needCap;

    Vector3 collisionPos;
    private bool bumped;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        direction = Vector2.zero;

        rb = GetComponent<Rigidbody>();

        canLaunch = true;

        hasLaunched = false;

        bumped = true;
    }

    void FixedUpdate()
    {
        if (moved)
        {
            rb.linearVelocity += new Vector3(0, 0, direction.z * speed);
        }

        //speed cap
        if (needCap)
        {
            if (rb.linearVelocity.x > 65f)
            {
                //Debug.Log("too fast x: " + rb.linearVelocity.x);
                rb.linearVelocity = new Vector3(65f, rb.linearVelocity.y, rb.linearVelocity.z);
            }
            if (rb.linearVelocity.y > 5f)
            {
                //Debug.Log("too fast y: " + rb.linearVelocity.y);
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 5f, rb.linearVelocity.z);
            }
            if (rb.linearVelocity.z > 65f)
            {
                //Debug.Log("too fast z: " + rb.linearVelocity.z);
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, 65f);
            }
        }

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, gravity * gravityspeed, rb.linearVelocity.z);
        //Debug.Log(rb.linearVelocity);
    }

    public void setMove(bool move)
    {
        canMove = move;
    }

    public void setCap(bool cap)
    {
        needCap = cap;
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

    public void getLaunchVector(InputAction.CallbackContext context)
    {
        if (canLaunch && canMove)
        {
            GetComponent<AudioSource>().Play();

            rb.AddForce(110f, 0f, 0f, ForceMode.Impulse);

            canLaunch = false;

            hasLaunched = true;
        }
    }

    public bool getHasLaunched()
    {
        return hasLaunched;
    }
}
