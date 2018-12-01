using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioRaycast : MonoBehaviour {

    int layerMask = 1 << 9;
    public float ElioVisionRange;
    RaycastHit hit;
    public static bool PlayerDetected;

    private void Start()
    {
        
    }

    void Update () {
      

        for (float i=0; i<360; i++)
        {
            float ElioRayX = ElioVisionRange * Mathf.Cos( i);
            float ElioRayY = ElioVisionRange * Mathf.Sin(i);

            Physics.Raycast(transform.position, transform.TransformDirection(ElioRayX, 0, ElioRayY), out hit, ElioVisionRange, layerMask);
            if (hit.collider.tag == "player")
            {
                PlayerDetected = true;
            }
            else
            {
                PlayerDetected = false;
            }

        }

	}
}
