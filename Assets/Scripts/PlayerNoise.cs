using UnityEngine;
using UnityEngine.Audio;

public class PlayerNoise : MonoBehaviour
{
    public AudioClip[] whistles;
    public AudioClip[] claps;
    public AudioClip found;
    public AudioMixerGroup audioMixer;
    public AudioSource audioSource;
    public static bool foundElio = false;

    void Update()
    {
        if (Input.GetButtonDown("Whistle"))
        {
            audioSource.Stop();
            audioSource.clip = whistles[Random.Range(0, whistles.Length)];
            audioSource.pitch = Random.Range(0.98f, 1.04f);
            audioSource.outputAudioMixerGroup = audioMixer;
            audioSource.Play();
        }
        if (foundElio)
        {
            audioSource.Stop();
            audioSource.clip = found;
            audioSource.outputAudioMixerGroup = audioMixer;
            audioSource.Play();
            foundElio = false;
        }
    }
}
