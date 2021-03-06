﻿using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ElioSounds : MonoBehaviour
{
    AudioClip[] footstepsBank;
    public Transform player;
    public AudioSource source;
    public AudioSource sourceFootsteps;
    public AudioClip[] count;
    public AudioClip[] farAway;
    public AudioClip[] found;
    public AudioClip[] giggles;
    public AudioClip[] late;
    public AudioClip[] runDirt;
    public AudioClip[] runGrass;
    public AudioClip[] runSnow;
    public AudioClip[] overHere;
    public AudioClip[] runWater;
    public AudioClip[] walkDirt;
    public AudioClip[] walkGrass;
    public AudioClip[] walkSnow;
    public AudioClip[] walkWater;
    public AudioMixer mixer;
    public AudioMixerGroup[] audioMixer;
    string surfaceTag;
    bool tooFar = false;
    public static bool elioFound = false;
    bool elioFoundFix = false;
    public static int gameOver = 0;
    public static bool isMoving = false;
    public static bool isRunning = false;

    private void Start()
    {
        CheckGround();
        StartCoroutine(Footsteps());
        StartCoroutine(FarAway());
    }

    private void Update()
    {
        if (gameOver == 1)
        {
            StopAllCoroutines();
            StartCoroutine(Late());
        }

        if (elioFound && !elioFoundFix)
        {
            elioFoundFix = true;
            StartCoroutine(Found());
        }

        CheckGround();
        if (Input.GetButtonDown("Whistle") && !PlayerNoise.justWhistled)
        {
            if (Vector3.Distance(player.position, transform.position) < 20)
            {
                mixer.SetFloat("ElioVoiceParam", 3);
                StartCoroutine(Giggles());
            }
            else
            {
                mixer.SetFloat("ElioVoiceParam", -6);
                StartCoroutine(OverHere());
            }
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
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.25f))
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
        source.volume = 0.8f;
        source.pitch = Random.Range(0.98f, 1.04f);
        source.outputAudioMixerGroup = audioMixer[0];
        source.Play();
    }

    IEnumerator OverHere()
    {
        source.Stop();
        yield return new WaitForSeconds(Random.Range(1.5f, 2.25f));
        source.clip = overHere[Random.Range(0, giggles.Length)];
        source.volume = 0.8f;
        source.pitch = Random.Range(0.98f, 1.04f);
        source.outputAudioMixerGroup = audioMixer[0];
        source.Play();
    }

    IEnumerator Found()
    {
        source.Stop();
        source.clip = found[Random.Range(0, found.Length)];
        source.volume = 0.8f;
        source.pitch = 1;
        source.outputAudioMixerGroup = audioMixer[0];
        source.Play();
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        source.Stop();
        source.clip = count[Random.Range(0, count.Length)];
        source.volume = 0.8f;
        source.pitch = 1;
        source.outputAudioMixerGroup = audioMixer[0];
        source.Play();
        yield return new WaitForSeconds(4);
        elioFound = false;
        elioFoundFix = false;
    }

    IEnumerator Late()
    {
        source.Stop();
        source.clip = late[Random.Range(0, late.Length)];
        source.volume = 0.8f;
        source.pitch = 1;
        source.outputAudioMixerGroup = audioMixer[0];
        source.Play();
        yield return new WaitForSeconds(1);
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

        yield return new WaitForSeconds(0.35f);
        StartCoroutine(Footsteps());
    }
}
