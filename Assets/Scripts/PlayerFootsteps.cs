using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerFootsteps : MonoBehaviour
{
    AudioClip[] footstepsBank;
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
    public static string surfaceTag;
    float stepDelay;

    void Start()
    {
        StartCoroutine(Footsteps());
    }

    void Update()
    {
        if (isRunning)
        {
            startedRunning++;
            stepDelay = 0.3f;
        }
        else
        {
            startedRunning = 0;
            stepDelay = 0.5f;
        }

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
            DetermineSurface();
            audioSource.clip = footstepsBank[Random.Range(0, footstepsBank.Length)];
            audioSource.pitch = Random.Range(0.85f, 1.15f);
            audioSource.outputAudioMixerGroup = audioMixer;
            audioSource.Play();
        }

        yield return new WaitForSeconds(stepDelay);

        StartCoroutine(Footsteps());
    }

    void DetermineSurface()
    {
        switch (surfaceTag)
        {
            case "Concrete":
                if (isRunning)
                    footstepsBank = runConcrete;
                else
                    footstepsBank = walkConcrete;
                break;

            case "Dirt":
                if (isRunning)
                    footstepsBank = runDirt;
                else
                    footstepsBank = walkDirt;
                break;

            case "Grass":
                if (isRunning)
                    footstepsBank = runGrass;
                else
                    footstepsBank = walkGrass;
                break;

            case "Gravel":
                if (isRunning)
                    footstepsBank = runGravel;
                else
                    footstepsBank = walkGravel;
                break;

            case "Indoors":
                if (isRunning)
                    footstepsBank = runIndoors;
                else
                    footstepsBank = walkIndoors;
                break;

            case "Metal":
                if (isRunning)
                    footstepsBank = runMetal;
                else
                    footstepsBank = walkMetal;
                break;

            case "Snow":
                if (isRunning)
                    footstepsBank = runSnow;
                else
                    footstepsBank = walkSnow;
                break;

            case "Water":
                if (isRunning)
                    footstepsBank = runWater;
                else
                    footstepsBank = walkWater;
                break;

            case "Wood":
                if (isRunning)
                    footstepsBank = runWood;
                else
                    footstepsBank = walkWood;
                break;

            default:
                if (isRunning)
                    footstepsBank = runGrass;
                else
                    footstepsBank = walkGrass;
                break;
        }
    }
}
