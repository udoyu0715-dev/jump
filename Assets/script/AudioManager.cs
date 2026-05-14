using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip bgmClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = bgmClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}