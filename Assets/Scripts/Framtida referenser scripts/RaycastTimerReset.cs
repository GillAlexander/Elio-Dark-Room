﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaycastTimerReset : MonoBehaviour {

    public float PlayerDetectedResetTimer;

    ElioRaycastV2 Raycast;
    void Start()
    {
        Raycast = GameObject.FindWithTag("ElioTest").GetComponent<ElioRaycastV2>();
       
    }
    


   public void TimerReset()
    {
        Debug.Log("RaycastTimerReset run");
        if (ElioRaycastV2.ElapsedTime >= PlayerDetectedResetTimer && Raycast.PlayerDetectedStandard == true)
        {
            Raycast.PlayerDetectedStandard = false;
            ElioRaycastV2.ElapsedTime = 0;
            Debug.Log("Timer and player detected reset");
        }
        else if (ElioRaycastV2.ElapsedTime >= PlayerDetectedResetTimer && Raycast.PlayerDetectedStandard == false)
        {
            ElioRaycastV2.ElapsedTime = 0;
            Debug.Log("Timer reset Standard");
        }

        else if (ElioRaycastV2.ElapsedTime >= PlayerDetectedResetTimer && Raycast.PlayerDetectedClose == true)
        {
            Raycast.PlayerDetectedClose = false;
            ElioRaycastV2.ElapsedTime = 0;
            Debug.Log("Timer and player detected reset");
        }
        else if (ElioRaycastV2.ElapsedTime >= PlayerDetectedResetTimer && Raycast.PlayerDetectedClose == false)
        {
            ElioRaycastV2.ElapsedTime = 0;
            Debug.Log("Timer reset");
        }

        else if (ElioRaycastV2.ElapsedTime >= PlayerDetectedResetTimer && Raycast.PlayerDetectedFarAway== true)
        {
            Raycast.PlayerDetectedFarAway = false;
            ElioRaycastV2.ElapsedTime = 0;
            Debug.Log("Timer and player detected reset");
        }
        else if (ElioRaycastV2.ElapsedTime >= PlayerDetectedResetTimer && Raycast.PlayerDetectedFarAway == false)
        {
            ElioRaycastV2.ElapsedTime = 0;
            Debug.Log("Timer reset");
        }
    }
}
