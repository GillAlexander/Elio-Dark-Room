using System;
using UnityEngine;
using UnityEngine.Audio;

public class ElioSounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] sounds;
    public AudioClip[] footsteps;
    public AudioMixerGroup[] mixerGroup;
    bool isMoving;

    void Start()
    {
        mixerGroup = new AudioMixerGroup[2];
        isMoving = false;
    }

    void Update()
    {
        //call Elio. JUMP KEY IS PLACEHOLDER!!
        if (Input.GetButtonDown("Jump"))
        {
            source.clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
            source.pitch = UnityEngine.Random.Range(0.9f, 1.15f);
            source.outputAudioMixerGroup = mixerGroup[0];

            if (source.isPlaying)
                return;
            else
                source.Play();
        }

        /*footsteps
        if (isMoving)
        {
            source.clip = footsteps[UnityEngine.Random.Range(0, sounds.Length)];
            source.pitch = UnityEngine.Random.Range(0.85f, 1.2f);
            source.outputAudioMixerGroup = mixerGroup[1];
            if (source.isPlaying)
                return;
            else
                source.Play();
        }
        */
    }
}
