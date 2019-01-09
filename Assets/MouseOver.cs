using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    AudioSource source;
    public AudioClip[] choices;
    public static string select = "";

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        switch (select)
        {
            case "Start":
                source.clip = choices[1];
                source.Play();
                break;

            case "About":
                source.clip = choices[2];
                source.Play();
                break;

            case "Settings":
                source.clip = choices[3];
                source.Play();
                break;

            case "Exit":
                source.clip = choices[4];
                source.Play();
                break;

            default:
                break;
        }
    }
}
