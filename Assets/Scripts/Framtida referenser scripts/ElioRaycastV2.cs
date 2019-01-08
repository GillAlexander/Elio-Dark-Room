using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioRaycastV2 : MonoBehaviour
{

    RaycastTimerReset raycastTimerReset;

    public float ElioDetectionRangeClose;
    public float ElioDetectionrangeFar;

    public float ElioVisionRange;

    public float RaycastDensity;



    public static float ElapsedTime = 0;

    public bool PlayerDetectedStandard = false;
    public bool PlayerDetectedFarAway = false;
    public bool PlayerDetectedClose = false;

    RaycastHit hit;

    private void Start()
    {
       raycastTimerReset = GameObject.FindWithTag("ElioTest").GetComponent<RaycastTimerReset>();
    }

    void Update()
    {
        ElapsedTime += Time.deltaTime;

        for (float i = 0; i < RaycastDensity; i++)
        {
            float ElioRayX = ElioVisionRange * Mathf.Cos(i);
            float ElioRayY = ElioVisionRange * Mathf.Sin(i);

            if (Physics.Raycast(transform.position, transform.TransformDirection(ElioRayX, 0, ElioRayY), out hit, ElioVisionRange))
            {
                Debug.DrawRay(transform.position, hit.point - transform.position, Color.red);

                if (hit.collider.tag == "Player" && hit.distance < ElioDetectionrangeFar && hit.distance > ElioDetectionRangeClose)
                {
                    PlayerDetectedStandard = true;
                    ElapsedTime = 0;
                    Debug.Log("PlayerDetectedStandard");
                }

                else if (hit.collider.tag == "Player" && hit.distance < ElioDetectionRangeClose && hit.distance < ElioDetectionrangeFar)
                {
                    PlayerDetectedClose = true;
                    ElapsedTime = 0;
                    Debug.Log("PlayerDetectedClose");
                }

                else if (hit.collider.tag == "Player" && hit.distance < ElioVisionRange && hit.distance > ElioDetectionrangeFar)
                {
                    PlayerDetectedFarAway = true;
                    ElapsedTime = 0;
                    Debug.Log("PlayerDetectedFarAway");
                }
            }

            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(ElioRayX, 0, ElioRayY), Color.red);
            }

        }

        raycastTimerReset.TimerReset();

    }

    

}

