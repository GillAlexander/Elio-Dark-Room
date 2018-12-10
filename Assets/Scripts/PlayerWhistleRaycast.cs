using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWhistleRaycast : MonoBehaviour {

    public GameObject EchoSource;

    public float WhistleRange;


    float EchoDistance;
    RaycastHit contact;

    private float time;
    
    void Start () {
      
	}
	

	void Update () {
        bool ElioWhistle = Input.GetButton("Whistle");

        if (ElioWhistle)
        {
            
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out contact, WhistleRange))
            {
                EchoDistance = contact.distance;
                Instantiate(EchoSource, contact.point.normalized, transform.rotation);
                Debug.Log("Player sees something: " + EchoDistance);
                Debug.DrawRay(transform.position, contact.point - transform.position, Color.red);

                Destroy(EchoSource, time);
            }
            
        }
    }
}
