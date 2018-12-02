using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioRaycast : MonoBehaviour {

    int layerMask = 1 << 9;
    public float ElioVisionRange;
    public float RaycastDensity;
    RaycastHit hit;
    public bool PlayerDetected;

       private void Start()
    {
        
    }

    void Update () {
      

        for (float i=0; i< RaycastDensity; i++)
        {
            float ElioRayX = ElioVisionRange * Mathf.Cos( i);
            float ElioRayY = ElioVisionRange * Mathf.Sin(i);
           
            Physics.Raycast(transform.position, transform.TransformDirection(ElioRayX, 0, ElioRayY), out hit, ElioVisionRange, layerMask);
            if (hit.CapsuleCollider.tag == "player")
            {
                PlayerDetected = true;
            }
           

            Debug.DrawRay(transform.position, transform.TransformDirection(ElioRayX, 0, ElioRayY), Color.red);

        }

	}
}
