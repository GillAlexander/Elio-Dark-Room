using UnityEngine;
using UnityEngine.Audio;

public class PlayerNoise : MonoBehaviour
{
    public AudioClip[] whistles;
    public AudioMixerGroup audioMixer;
    public AudioSource audioSource;
    
    
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
    }
}
