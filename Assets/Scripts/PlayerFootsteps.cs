using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] walkConcrete;
    public AudioClip[] walkDirt;
    public AudioClip[] walkGrass;
    public AudioClip[] walkGravel;
    public AudioClip[] walkIndoors;
    public AudioClip[] walkMetal;
    public AudioClip[] walkSnow;
    public AudioClip[] walkWater;
    public AudioClip[] walkWood;
    public AudioClip[] runConcrete;
    public AudioClip[] runDirt;
    public AudioClip[] runGrass;
    public AudioClip[] runGravel;
    public AudioClip[] runIndoors;
    public AudioClip[] runMetal;
    public AudioClip[] runSnow;
    public AudioClip[] runWater;
    public AudioClip[] runWood;
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
            source.Stop();

            if (isRunning)
                source.clip = runGrass[Random.Range(0, walkGrass.Length)];
            else
                source.clip = walkGrass[Random.Range(0, walkGrass.Length)];

            source.pitch = Random.Range(0.85f, 1.15f);
            source.outputAudioMixerGroup = audioMixer;
            source.Play();
        }

        if (isRunning)
            yield return new WaitForSeconds(0.3f);
        else
            yield return new WaitForSeconds(0.5f);

        StartCoroutine(Footsteps());
    }
}
