using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {
    private ElioRaycast ElioRaycastReference;
    public AudioSource detected;

    void Start()
    {
        ElioRaycastReference = GameObject.Find("ElioRaycast").GetComponent<ElioRaycast>();
    }

    void update()
    {
        if (ElioRaycast.PlayerDetected==true)
        {
            detected.Play();
        }
    }
}
