using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchBetweenCameras : MonoBehaviour {

    public Camera playerCamera;

    public Camera elioCamera;
    
	// Use this for initialization
	void Start () {
        playerCamera.gameObject.SetActive(true);
        elioCamera.gameObject.SetActive(false);

        elioCamera.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (elioCamera.gameObject != null)
        {
            if (InputManager.YButton())
            {
                playerCamera.gameObject.SetActive(false);
                elioCamera.gameObject.SetActive(true);
            }
            else
            {
                playerCamera.gameObject.SetActive(true);
                elioCamera.gameObject.SetActive(false);
            }
        }
        else
        {
            return;
        }

	}
}
