using System.Collections;
using UnityEngine;

public class MouseOverSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] choices;
    public static string select = "";
    public static bool pointerEnter = false;
    public static bool pointerFix = false;
    bool timer = false;

    private void Update()
    {
        switch (select)
        {
            case "Start":
                source.clip = choices[0];
                if (!timer && pointerEnter && !pointerFix)
                {
                    timer = true;
                    source.Play();
                    pointerFix = pointerEnter;
                    StartCoroutine(Delay());
                }
                break;

            case "About":
                source.clip = choices[1];
                if (!timer && pointerEnter && !pointerFix)
                {
                    timer = true;
                    source.Play();
                    pointerFix = pointerEnter;
                    StartCoroutine(Delay());
                }
                break;

            case "Settings":
                source.clip = choices[2];
                if (!timer && pointerEnter && !pointerFix)
                {
                    timer = true;
                    source.Play();
                    pointerFix = pointerEnter;
                    StartCoroutine(Delay());
                }
                break;

            case "Exit":
                source.clip = choices[3];
                if (!timer && pointerEnter && !pointerFix)
                {
                    timer = true;
                    source.Play();
                    pointerFix = pointerEnter;
                    StartCoroutine(Delay());
                }
                break;

            default:
                break;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        timer = false;
    }
}
