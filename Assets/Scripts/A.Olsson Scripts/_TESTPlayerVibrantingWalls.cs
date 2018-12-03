using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class _TESTPlayerVibrantingWalls : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
	    
	}
    void onTriggerEnter(Collision wall)
    {
        if (wall.gameObject.name == ("BOLL"))
        {
            Destroy(wall.gameObject);
        }
    }
}