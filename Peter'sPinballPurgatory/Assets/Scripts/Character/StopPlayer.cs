using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    MoveCharacter player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<MoveCharacter>();
    }

    public void setcantMove()
    {
        player.setMove(false);
    }

    public void setcanMove()
    {
        player.setMove(true);
    }
}
