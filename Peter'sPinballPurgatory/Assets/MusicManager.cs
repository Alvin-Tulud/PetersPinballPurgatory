using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;

    public void PlayMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
}
