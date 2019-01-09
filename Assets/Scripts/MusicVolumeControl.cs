using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class MusicVolumeControl : MonoBehaviour
{
    public AudioMixer mixer;
    float volume;

    void Start()
    {
        volume = -60;
        StartCoroutine(MusicFade());
    }

    IEnumerator MusicFade()
    {
        mixer.SetFloat("MusicParam", volume);
        volume += 1.5f;

        yield return new WaitForSeconds(0.1f);

        if (volume < -29)
            StartCoroutine(MusicFade());
    }
}
