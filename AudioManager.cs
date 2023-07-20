using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Reference to the background music audio clip.

    private AudioSource audioSource;

    private void Awake()
    {
        Debug.Log("AudioManager Awake()");
        audioSource = GetComponent<AudioSource>();
        PlayBackgroundMusic();
    }


    private void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
