using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioRaycastTester : MonoBehaviour {
    private ElioRaycast ElioRaycastReference;
    
    void Start()
    {
        ElioRaycastReference = GameObject.Find("ElioRaycastTest").GetComponent<ElioRaycast>();
    }

    void update()
    {
        if (ElioRaycast.PlayerDetected == true)
        {
            Debug.Log("Player detedted");
        }
    }


}
