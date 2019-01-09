using UnityEngine;

public class MouseOver : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] choices;
    public static string select = "";
    public static bool pointerEnter = false;
    public static bool pointerFix = false;

    private void Update()
    {
        switch (select)
        {
            case "Start":
                source.clip = choices[0];
                if (pointerEnter && !pointerFix)
                {
                    source.Play();
                    pointerFix = pointerEnter;
                }
                break;

            case "About":
                source.clip = choices[1];
                if (pointerEnter && !pointerFix)
                {
                    source.Play();
                    pointerFix = pointerEnter;
                }
                break;

            case "Settings":
                source.clip = choices[2];
                if (pointerEnter && !pointerFix)
                {
                    source.Play();
                    pointerFix = pointerEnter;
                }
                break;

            case "Exit":
                source.clip = choices[3];
                if (pointerEnter && !pointerFix)
                {
                    source.Play();
                    pointerFix = pointerEnter;
                }
                break;

            default:
                break;
        }
    }
}
