using Unity.VisualScripting;
using UnityEngine;

public class BumperHit : MonoBehaviour
{
    float bumperforcemin = 20f;
    float bumperforcemax = 40f;

    

    BumperStats bstats;

    AudioSource bsource;

    private void Start()
    {
        bsource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float randbumperforce = UnityEngine.Random.Range(bumperforcemin, bumperforcemax);
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddExplosionForce(randbumperforce, transform.position, 360f, 0f, ForceMode.VelocityChange);

            float pitch = Random.Range(-0.8f, 1.2f);
            bsource.pitch = pitch;
            bsource.Play();
        }
    }
}
