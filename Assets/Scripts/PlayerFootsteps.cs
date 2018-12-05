using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] footsteps;
    public AudioMixerGroup audioMixer;
    public static bool isMoving;

    void Start()
    {
        StartCoroutine(Footsteps());
    }

    IEnumerator Footsteps()
    {
        if (isMoving)
        {
            source.Stop();
            source.clip = footsteps[Random.Range(0, footsteps.Length)];
            source.pitch = Random.Range(0.85f, 1.2f);
            source.outputAudioMixerGroup = audioMixer;
            source.Play();
        }

        if (Input.GetButton("Sprint"))
            yield return new WaitForSeconds(0.3f);
        else
            yield return new WaitForSeconds(0.5f);

        StartCoroutine(Footsteps());
    }
}
