using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BirdMovement : MonoBehaviour {
    
    private Vector3 birdDirection;

   
    public float flightSpeed = 2;

    private float movementX;
    private float movementZ;

    public float flightHeight;
    
    void Start () {

        movementX=flightSpeed;
        movementZ = flightSpeed;
    }
	
	void Update () {

        if (transform.position.x > 400)
        {
            movementX = movementX * (-1);
            
            Debug.Log("x1");
        }
        else if (transform.position.x < (-30))
        {
            movementX = movementX * (-1);
           
            Debug.Log("x2");
        }
        else if (transform.position.z < 0)
        {
           
            movementZ = movementZ * (-1);
            Debug.Log("z1");
        }
        else if (transform.position.z > (380))
        {
            
            movementZ = movementZ * (-1);
            Debug.Log("z1");
        }

        

        birdDirection = new Vector3(transform.position.x + movementX, flightHeight, transform.position.z+movementZ);
        transform.position = birdDirection;

        if (movementX<0 && movementZ <0)
        {
           // transform.rotation = Quaternion.Slerp();
        }

	}
}
