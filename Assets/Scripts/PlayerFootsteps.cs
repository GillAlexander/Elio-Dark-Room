using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioClip[] footstepsBank;
    public AudioClip[] runDirt;
    public AudioClip[] runGrass;
    public AudioClip[] runGravel;
    public AudioClip[] runSnow;
    public AudioClip[] runWater;
    public AudioClip[] runWood;
    public AudioClip[] walkDirt;
    public AudioClip[] walkGrass;
    public AudioClip[] walkGravel;
    public AudioClip[] walkSnow;
    public AudioClip[] walkWater;
    public AudioClip[] walkWood;
    public AudioSource audioSource;
    public AudioMixerGroup audioMixer;
    public static bool isMoving = false;
    public static bool isRunning = false;
    public static int startedRunning;
    string surfaceTag;
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
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
                    surfaceTag = hit.transform.tag;
                else
                    surfaceTag = "Grass";
            }
        }
        else
            surfaceTag = "Grass";
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
