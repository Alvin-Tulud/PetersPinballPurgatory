using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera m_Camera;
    Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Camera = Camera.main;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            m_Camera.transform.position = new Vector3(player.position.x, player.position.y + 15f, player.position.z);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
}
