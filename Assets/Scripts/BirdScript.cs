using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public AudioClip[] birdCalls;
    public AudioSource source;

    void Start()
    {
        StartCoroutine(Chirp());
        source = GetComponent<AudioSource>();
    }

    IEnumerator Chirp()
    {
        if (birdCalls.Length < 2)
            yield return new WaitForSeconds(Random.Range(9, 15));
        else
            yield return new WaitForSeconds(Random.Range(3, 7));

        source.clip = birdCalls[Random.Range(0, birdCalls.Length)];
        source.pitch = Random.Range(0.95f, 1.05f);
        source.Play();
        StartCoroutine(Chirp());
    }
}
