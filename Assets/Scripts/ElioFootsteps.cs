using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ElioFootsteps : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] footsteps;
    public AudioMixerGroup audioMixer;
    bool isMoving;

    void Start()
    {
        StartCoroutine(Footsteps());
    }

    IEnumerator Footsteps()
    {
//Insert villkor här för Elio movement. PLACEHOLDER!!!
        if (true)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving)
        {
            source.clip = footsteps[Random.Range(0, footsteps.Length)];
            source.pitch = Random.Range(0.85f, 1.2f);
            source.outputAudioMixerGroup = audioMixer;
            source.Play();
        }

        yield return new WaitForSeconds(1);
        StartCoroutine(Footsteps());
    }
}
