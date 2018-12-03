using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ElioSounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] sounds;
    public AudioMixerGroup audioMixer;

    void Start()
    {
        StartCoroutine(Sounds());
    }

    IEnumerator Sounds()
    {
        //call Elio. JUMP KEY IS PLACEHOLDER!!
        if (Input.GetButtonDown("Jump"))
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.pitch = Random.Range(0.85f, 1.2f);
            source.outputAudioMixerGroup = audioMixer;
            source.Play();
        }

        yield return new WaitForSeconds(2);
        StartCoroutine(Sounds());
    }
}
