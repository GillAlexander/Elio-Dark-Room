using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioClip[] runConcrete;
    public AudioClip[] runDirt;
    public AudioClip[] runGrass;
    public AudioClip[] runGravel;
    public AudioClip[] runIndoors;
    public AudioClip[] runMetal;
    public AudioClip[] runSnow;
    public AudioClip[] runWater;
    public AudioClip[] runWood;
    public AudioClip[] walkConcrete;
    public AudioClip[] walkDirt;
    public AudioClip[] walkGrass;
    public AudioClip[] walkGravel;
    public AudioClip[] walkIndoors;
    public AudioClip[] walkMetal;
    public AudioClip[] walkSnow;
    public AudioClip[] walkWater;
    public AudioClip[] walkWood;
    public AudioSource audioSource;
    public AudioMixerGroup audioMixer;
    public static bool isMoving = false;
    public static bool isRunning = false;
    public static int startedRunning;

    void Start()
    {
        StartCoroutine(Footsteps());
    }

    void Update()
    {
        if (isRunning)
            startedRunning++;
        else
            startedRunning = 0;

        if (startedRunning == 1)
        {
            StopAllCoroutines();
            StartCoroutine(Footsteps());
        }
    }

    public IEnumerator Footsteps()
    {
        if (isMoving)
        {
            audioSource.Stop();

            if (isRunning)
                audioSource.clip = runGrass[Random.Range(0, walkGrass.Length)];
            else
                audioSource.clip = walkGrass[Random.Range(0, walkGrass.Length)];

            audioSource.pitch = Random.Range(0.85f, 1.15f);
            audioSource.outputAudioMixerGroup = audioMixer;
            audioSource.Play();
        }

        if (isRunning)
            yield return new WaitForSeconds(0.3f);
        else
            yield return new WaitForSeconds(0.5f);

        StartCoroutine(Footsteps());
    }
}
