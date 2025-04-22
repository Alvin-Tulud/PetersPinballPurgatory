using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    //camera smoothdamp copied from https://www.youtube.com/watch?v=ZBj3LBA2vUY&ab_channel=bendux
    private Camera m_Camera;
    private Transform player;
    public float distFromPlayer;

    private Vector3 offset;
    public float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Camera = Camera.main;
        player = GameObject.FindWithTag("Player").transform;

        offset = new Vector3(0f, distFromPlayer, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            Vector3 targetPosition = player.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
}
