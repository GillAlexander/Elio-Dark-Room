using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWhistleRaycast : MonoBehaviour {
    public float WhistleRange;
    float EchoDistance;
    RaycastHit contact;

    
    void Start () {
      
	}
	

	void Update () {

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out contact, WhistleRange))
        {
            EchoDistance = contact.distance;
            Debug.Log("Player sees something: "+EchoDistance);
        }
        Debug.DrawRay(transform.position, contact.point - transform.position, Color.blue);
    }
}
