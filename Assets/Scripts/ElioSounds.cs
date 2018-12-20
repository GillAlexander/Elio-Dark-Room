using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ElioSounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] farAway;
    public AudioClip[] giggles;
    public AudioClip[] overHere;
    public AudioClip[] footsteps;
    public AudioMixerGroup[] audioMixer;

    bool isMoving = false;

    private void Start()
    {
        StartCoroutine(Footsteps());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Whistle"))
            StartCoroutine(OverHere());


    }

    IEnumerator FarAway()
    {
        source.Stop();
        yield return new WaitForSeconds(Random.Range(1.5f, 2.25f));
        source.clip = farAway[Random.Range(0, giggles.Length)];
        source.pitch = Random.Range(0.98f, 1.04f);
        source.outputAudioMixerGroup = audioMixer[0];
        source.Play();
    }

    IEnumerator Giggles()
    {
        source.Stop();
        yield return new WaitForSeconds(Random.Range(1.5f, 2.25f));
        source.clip = giggles[Random.Range(0, giggles.Length)];
        source.pitch = Random.Range(0.98f, 1.04f);
        source.outputAudioMixerGroup = audioMixer[0];
        source.Play();
    }

    IEnumerator OverHere()
    {
        source.Stop();
        yield return new WaitForSeconds(Random.Range(1.5f, 2.25f));
        source.clip = overHere[Random.Range(0, giggles.Length)];
        source.pitch = Random.Range(0.98f, 1.04f);
        source.outputAudioMixerGroup = audioMixer[0];
        source.Play();
    }

    IEnumerator Footsteps()
    {
        if (isMoving)
        {
            source.Stop();
            source.clip = footsteps[Random.Range(0, footsteps.Length)];
            source.pitch = Random.Range(0.85f, 1.2f);
            source.outputAudioMixerGroup = audioMixer[1];
            source.Play();
        }
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(Footsteps());
    }
}
