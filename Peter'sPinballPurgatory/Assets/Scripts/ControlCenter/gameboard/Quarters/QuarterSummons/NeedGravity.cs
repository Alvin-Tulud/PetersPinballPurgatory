using System.Collections;
using UnityEngine;

public class NeedGravity : MonoBehaviour
{
    private const float gravity = -9.81f;
    public float gravityspeed;
    Rigidbody rb;

    private bool bumped;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        bumped = true;
    }

    // Update is called once per frame
    void Update()
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

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, gravity * gravityspeed, rb.linearVelocity.z);
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
}
