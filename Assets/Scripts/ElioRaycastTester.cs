using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioRaycastTester : MonoBehaviour {
    public ElioRaycast ER;
    
    void Start()
    {
        ER = GameObject.FindWithTag("ElioRaycastTest").GetComponent<ElioRaycast>();
    }

    void update()
    {
        if (ER.PlayerDetected==true)
        {
            Debug.Log("Player detected");
        }
    }


}
