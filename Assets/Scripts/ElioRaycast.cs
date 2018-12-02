using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioRaycast : MonoBehaviour {

    int layerMask = 1 << 9;
    public float ElioVisionRange;
    public float RaycastDensity;
    RaycastHit hit;
    public bool PlayerDetected;
    public AudioSource detected;

    private void Start()
    {
        
    }

    void Update () {
      

        for (float i=0; i< RaycastDensity; i++)
        {
            float ElioRayX = ElioVisionRange * Mathf.Cos( i);
            float ElioRayY = ElioVisionRange * Mathf.Sin(i);
            Debug.DrawRay(transform.position, transform.TransformDirection(ElioRayX, 0, ElioRayY), Color.red);

            if (Physics.Raycast(transform.position, transform.TransformDirection(ElioRayX, 0, ElioRayY), out hit, ElioVisionRange, layerMask))
            {
                PlayerDetected = true;
                Debug.Log("Player detected");
                detected.Play();
            }
           

            

        }

	}
}
