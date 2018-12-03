using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioRaycast : MonoBehaviour {

    

    public float ElioVisionRange;
    public float RaycastDensity;

    RaycastHit hit;
    public bool PlayerDetected=false;


    private void Start()
    {
        
    }

    void Update () {
        int elioLayerMask = 1 << 9;

        elioLayerMask = ~elioLayerMask;

        for (float i=0; i< RaycastDensity; i++)
        {
            float ElioRayX = ElioVisionRange * Mathf.Cos( i);
            float ElioRayY = ElioVisionRange * Mathf.Sin(i);

            if (Physics.Raycast(transform.position, transform.TransformDirection(ElioRayX, 0, ElioRayY), out hit, ElioVisionRange, elioLayerMask))
            {
                Debug.DrawRay(transform.position, hit.point - transform.position, Color.red);
                PlayerDetected = true;
                
                           }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(ElioRayX, 0, ElioRayY), Color.red);
            }
           

            

        }

	}
}
