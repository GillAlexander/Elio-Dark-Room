using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioAudioManager : MonoBehaviour
{
    private ElioRaycast ElioRaycastReference;
    public AudioSource detected;

    void Start()
    {
        ElioRaycastReference = GameObject.Find("ElioRaycast").GetComponent<ElioRaycast>();
    }

    void update()
    {
        if (ElioRaycastReference.PlayerDetected==true)
        {
            detected.Play();
        }
    }
}
