using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BumperHit : MonoBehaviour
{
    float bumperforcemin = 20f;
    float bumperforcemax = 40f;

    public float pitchmin;
    public float pitchmax;

    BumperStats bstats;

    AudioSource bsource;

    Light blight;

    private void Start()
    {
        bstats = GetComponent<BumperStats>();
        bsource = GetComponent<AudioSource>();
        blight = GetComponent<Light>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("FakePlayer"))
        {
            float randbumperforce = UnityEngine.Random.Range(bumperforcemin, bumperforcemax);
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddExplosionForce(randbumperforce, transform.position, 360f, 0f, ForceMode.VelocityChange);

            float pitch = Random.Range(pitchmin, pitchmax);
            bsource.pitch = pitch;
            bsource.Play();
            StartCoroutine(lightcooldown());

            FindAnyObjectByType<ScoreTracker>().AddScore(bstats.getScore());
            FindAnyObjectByType<RoundStatTracker>().AddBump();
        }
    }

    IEnumerator lightcooldown()
    {
        blight.enabled = true;

        yield return new WaitForSeconds(0.25f);

        blight.enabled = false;
    }
}
