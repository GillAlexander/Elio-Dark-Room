using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioRaycast : MonoBehaviour {
    
    public float ElioVisionRange;
    public float RaycastDensity;
    public float PlayerDetectedResetTimer;

    float ElapsedTime = 0;

    public bool PlayerDetectedStandard = false;

    RaycastHit hit;
    
    void Update () {
        ElapsedTime += Time.deltaTime;

        for (float i=0; i< RaycastDensity; i++)
        {
            float ElioRayX = ElioVisionRange * Mathf.Cos( i);
            float ElioRayY = ElioVisionRange * Mathf.Sin(i);

            if (Physics.Raycast(transform.position, transform.TransformDirection(ElioRayX, 0, ElioRayY), out hit, ElioVisionRange))       
            {
                Debug.DrawRay(transform.position, hit.point - transform.position, Color.red);

                if (hit.collider.tag=="Player")
                {
                    PlayerDetectedStandard = true;
                    ElapsedTime = 0;
                    Debug.Log("Timer reset in for loop");
                   
                }
            }

            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(ElioRayX, 0, ElioRayY), Color.red);
            }                 

        }

        RaycastTimerReset();
                     
    }

        void RaycastTimerReset()
        {
        Debug.Log("RaycastTimerReset run");
            if (ElapsedTime >= PlayerDetectedResetTimer && PlayerDetectedStandard == true)
            {
                PlayerDetectedStandard = false;
                ElapsedTime = 0;
                Debug.Log("Timer and player detected reset");
            }
            else if (ElapsedTime >= PlayerDetectedResetTimer && PlayerDetectedStandard == false)
            {
                ElapsedTime = 0;
                Debug.Log("Timer reset");
            }
        }

}
