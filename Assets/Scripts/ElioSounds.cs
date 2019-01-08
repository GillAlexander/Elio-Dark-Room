using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ElioSounds : MonoBehaviour
{
    public Transform player;
    public AudioSource source;
    public AudioSource sourceFootsteps;
    public AudioClip[] farAway;
    public AudioClip[] giggles;
    public AudioClip[] overHere;
    AudioClip[] footstepsBank;
    public AudioClip[] runDirt;
    public AudioClip[] runGrass;
    public AudioClip[] runSnow;
    public AudioClip[] runWater;
    public AudioClip[] walkDirt;
    public AudioClip[] walkGrass;
    public AudioClip[] walkSnow;
    public AudioClip[] walkWater;
    public AudioMixerGroup[] audioMixer;
    string surfaceTag;
    bool tooFar = false;
    public static bool isMoving = false;
    public static bool isRunning = false;

    private void Start()
    {
        StartCoroutine(Footsteps());
        StartCoroutine(FarAway());
    }

    private void Update()
    {
        CheckGround();
        if (Input.GetButtonDown("Whistle") && !PlayerNoise.justWhistled)
        {
            if (Vector3.Distance(player.position, transform.position) < 20)
                StartCoroutine(Giggles());
            else
                StartCoroutine(OverHere());
        }

        if (Vector3.Distance(player.position, transform.position) > 50)
            tooFar = true;
        else
            tooFar = false;
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


    IEnumerator FarAway()
    {
        if (tooFar)
        {
            source.Stop();
            source.clip = farAway[Random.Range(0, giggles.Length)];
            source.volume = 1;
            source.pitch = Random.Range(0.98f, 1.04f);
            source.outputAudioMixerGroup = audioMixer[0];
            source.Play();
        }

        yield return new WaitForSeconds(Random.Range(3f, 4f));
        StartCoroutine(FarAway());
    }

    IEnumerator Giggles()
    {
        source.Stop();
        yield return new WaitForSeconds(Random.Range(1.5f, 2.25f));
        source.clip = giggles[Random.Range(0, giggles.Length)];
        source.volume = 0.6f;
        source.pitch = Random.Range(0.98f, 1.04f);
        source.outputAudioMixerGroup = audioMixer[0];
        source.Play();
    }

    IEnumerator OverHere()
    {
        source.Stop();
        yield return new WaitForSeconds(Random.Range(1.5f, 2.25f));
        source.clip = overHere[Random.Range(0, giggles.Length)];
        source.volume = 1;
        source.pitch = Random.Range(0.98f, 1.04f);
        source.outputAudioMixerGroup = audioMixer[0];
        source.Play();
    }

    IEnumerator Footsteps()
    {
        if (isMoving)
        {
            sourceFootsteps.Stop();
            sourceFootsteps.clip = footstepsBank[Random.Range(0, footstepsBank.Length)];
            sourceFootsteps.pitch = Random.Range(0.85f, 1.15f);
            sourceFootsteps.outputAudioMixerGroup = audioMixer[1];
            sourceFootsteps.Play();
        }

        yield return new WaitForSeconds(0.4f);
        StartCoroutine(Footsteps());
    }
}
