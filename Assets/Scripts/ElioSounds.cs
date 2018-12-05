using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ElioSounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] sounds;
    public AudioClip[] footsteps;
    public AudioMixerGroup[] audioMixer;
    bool isMoving = false;

    private void Start()
    {
        StartCoroutine(Footsteps());
    }

    private void Update()
    {
        //call Elio. JUMP KEY IS PLACEHOLDER!!
        if (Input.GetButtonDown("Jump"))
        {
            source.Stop();
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.pitch = Random.Range(0.85f, 1.2f);
            source.outputAudioMixerGroup = audioMixer[0];
            source.Play();
        }

        if (isMoving)
        {
            isMoving = true;
        }
        else
            isMoving = false;
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
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Footsteps());
    }
}
