using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class WindControl : MonoBehaviour
{
    public AudioMixer mixer;
    bool snowSwap;
    bool onSnow = false;
    float windChange = -5;

    void Update()
    {
        if (PlayerFootsteps.surfaceTag == "Snow")
        {
            snowSwap = onSnow;
            onSnow = true;
        }
        else
        {
            snowSwap = onSnow;
            onSnow = false;
        }

        if (onSnow != snowSwap)
        {
            StartCoroutine(WindFade());
        }

    }

    IEnumerator WindFade()
    {
        mixer.SetFloat("WindParam", windChange);
        if (onSnow && windChange < 4)
        {
            windChange += 0.2f;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(WindFade());
        }

        else if (!onSnow && windChange > -5)
        {
            windChange -= 0.2f;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(WindFade());
        }
    }
}
