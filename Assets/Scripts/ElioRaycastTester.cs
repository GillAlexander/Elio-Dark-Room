using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioRaycastTester : MonoBehaviour {
    public ElioRaycast ER;
    
    void Start()
    {
        ER = GameObject.FindWithTag("ElioTest").GetComponent<ElioRaycast>();
    }

    void Update()
    {
        if (ER.PlayerDetectedStandard==true)
        {
            Debug.Log("Player detected");

        }
        else if(ER.PlayerDetectedStandard==false)
        {
            Debug.Log("Player hidden");
        }
    }


}
