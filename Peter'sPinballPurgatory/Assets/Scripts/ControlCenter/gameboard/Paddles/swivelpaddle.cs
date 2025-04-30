using System.Collections;
using UnityEngine;

public class swivelpaddle : MonoBehaviour
{
    public enum side
    {
        Left = 0,
        Right,
    }

    public side paddleside;
    private float swingangleinit, swinganglemax;
    private int currenttime;
    public int swingtime;
    private bool swingin, swingout;
    private bool startswing;

    private bool starttest;
    private bool callfirst;

    public float pitchmin;
    public float pitchmax;

    AudioSource bsource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (paddleside == side.Left)
        {
            swinganglemax = 240;
            swingangleinit = 300;
        }
        else
        {
            swinganglemax = 120;
            swingangleinit = 60;
        }

        swingin = true;
        swingout = false;

        starttest = true;
        callfirst = true;

        bsource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (starttest)
        {
            StartCoroutine(Tryswing());
        }
    }

    IEnumerator Tryswing()
    {
        starttest = false;

        float rand = Random.Range(0f, 1f);;

        if (rand > 0.5f)
        {
            startswing = true;
            swingin = true;
            callfirst = true;
        }

        yield return new WaitForSeconds(0.5f);

        starttest = true;
    }

    void FixedUpdate()
    {
        if (startswing)
        {
            if (callfirst)
            {
                float pitch = Random.Range(pitchmin, pitchmax);
                bsource.pitch = pitch;
                bsource.Play();

                callfirst = false;
            }

            if (swingin && currenttime < swingtime)
            {
                transform.GetChild(0).GetComponent<getcollhit>().setCanHit(true);

                float swingangle = (swinganglemax - swingangleinit) / 5;
                transform.Rotate(0, swingangle, 0);

                //Debug.Log(swingangle + paddleside.ToString() + " in");

                currenttime++;
            }
            else if (swingin && currenttime >= swingtime)
            {
                currenttime = 0;

                swingin = false;
                swingout = true;
            }
            else if (swingout && currenttime < swingtime)
            {
                transform.GetChild(0).GetComponent<getcollhit>().setCanHit(false);

                float swingangle = (swingangleinit - swinganglemax) / swingtime;
                transform.Rotate(0, swingangle, 0);

                //Debug.Log(swingangle + paddleside.ToString() + " out");

                currenttime++;
            }
            else if (swingout && currenttime >= swingtime)
            {
                currenttime = 0;

                swingout = false;
                startswing = false;
            }

            //Debug.Log(transform.rotation.eulerAngles.y);
        }   
    }

    public void setStartSwing(bool startswing)
    {
        this.startswing = startswing;
    }
}
