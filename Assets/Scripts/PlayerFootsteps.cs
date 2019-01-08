using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerFootsteps : MonoBehaviour
{
    AudioClip[] footstepsBank;
    public AudioClip[] runDirt;
    public AudioClip[] runGrass;
    public AudioClip[] runSnow;
    public AudioClip[] runWater;
    public AudioClip[] walkDirt;
    public AudioClip[] walkGrass;
    public AudioClip[] walkSnow;
    public AudioClip[] walkWater;
    public AudioSource audioSource;
    public AudioMixerGroup audioMixer;
    public AudioMixer mixer;
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
        CheckGround();
        if (isRunning)
        {
            startedRunning++;
            stepDelay = 0.4f;
        }
        else
        {
            startedRunning = 0;
            stepDelay = 0.7f;
        }

        if (startedRunning == 1)
        {
            StopAllCoroutines();
            StartCoroutine(Footsteps());
        }
    }

    void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            surfaceTag = hit.transform.tag;

            if (hit.transform.tag == "Water")
            {
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
                    surfaceTag = hit.transform.tag;
                else
                    surfaceTag = "Grass";
            }
        }
        else
            surfaceTag = "Grass";

        switch (surfaceTag)
        {
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

            default:
                if (isRunning)
                    footstepsBank = runGrass;
                else
                    footstepsBank = walkGrass;
                break;
        }
    }

    IEnumerator Footsteps()
    {
        if (isMoving)
        {
            audioSource.Stop();
            if (surfaceTag == "Water")
                mixer.SetFloat("FootstepsParam", 4);
            else
                mixer.SetFloat("FootstepsParam", -4);

            audioSource.clip = footstepsBank[Random.Range(0, footstepsBank.Length)];
            audioSource.pitch = Random.Range(0.85f, 1.15f);
            audioSource.outputAudioMixerGroup = audioMixer;
            audioSource.Play();
        }

        yield return new WaitForSeconds(stepDelay);
        StartCoroutine(Footsteps());
    }
}
