using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerNoise : MonoBehaviour
{
    public AudioClip[] whistles;
    public AudioClip found;
    public AudioMixerGroup audioMixer;
    public AudioSource audioSource;
    public static bool foundElio = false;
    bool justWhistled = false;

    void Update()
    {
        if (Input.GetButtonDown("Whistle") && !justWhistled)
        {
            justWhistled = true;
            StartCoroutine(Whistle());
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

    IEnumerator Whistle()
    {
        audioSource.Stop();
        audioSource.clip = whistles[Random.Range(0, whistles.Length)];
        audioSource.pitch = Random.Range(0.98f, 1.04f);
        audioSource.outputAudioMixerGroup = audioMixer;
        audioSource.Play();
        yield return new WaitForSeconds(4);
        justWhistled = false;
    }
}
