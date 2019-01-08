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
    public AudioClip[] footsteps;
    public AudioMixerGroup[] audioMixer;
    bool tooFar = false;
    public static bool isMoving = false;

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
            PlayerFootsteps.surfaceTag = hit.transform.tag;

            if (hit.transform.tag == "Water")
            {
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
                    PlayerFootsteps.surfaceTag = hit.transform.tag;
                else
                    PlayerFootsteps.surfaceTag = "Grass";
            }
        }
        else
            PlayerFootsteps.surfaceTag = "Grass";
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
        Debug.Log("Inne i Footsteps");
        if (isMoving)
        {
            Debug.Log("isMoving är true");
            sourceFootsteps.Stop();
            sourceFootsteps.clip = footsteps[Random.Range(0, footsteps.Length)];
            sourceFootsteps.pitch = Random.Range(0.85f, 1.2f);
            sourceFootsteps.outputAudioMixerGroup = audioMixer[1];
            sourceFootsteps.Play();
        }

        yield return new WaitForSeconds(0.4f);
        StartCoroutine(Footsteps());
    }
}
