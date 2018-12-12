using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWhistleRaycast : MonoBehaviour {

    public GameObject EchoSource;
    private GameObject instantiatedEchoSource;

    public float WhistleRange;


    public float echoCooldown;
    float time = 0;

    RaycastHit contact;
    
    void Start ()
    {
      
	}
	

	void Update ()
    {
        bool ElioWhistle = Input.GetButton("Clap");
        time += Time.deltaTime;
        if (ElioWhistle && time >= echoCooldown)
        {

            

            if (Physics.Raycast(transform.position, transform.forward, out contact, WhistleRange))
            {
                StartCoroutine(EchoDelay(contact.distance));
                Debug.DrawRay(transform.position, contact.point - transform.position, Color.red, WhistleRange);
               
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(-1, 0, 1), out contact, WhistleRange))
            {
                StartCoroutine(EchoDelay(contact.distance));
                Debug.DrawRay(transform.position, contact.point - transform.position, Color.red, WhistleRange);
             
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(1, 0, 1), out contact, WhistleRange))
            {
                StartCoroutine(EchoDelay(contact.distance));
                Debug.DrawRay(transform.position, contact.point-transform.position, Color.red, WhistleRange);
                
            }


            time = 0;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out contact, WhistleRange))
        {
           
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(-20, 0, 1), out contact, WhistleRange))
        {
            
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(20, 0, 1), out contact, WhistleRange))
        {
            
        }
    }

    IEnumerator EchoDelay(float EchoDistance)
    {
  
        yield return new WaitForSeconds(EchoDistance/10);
        Debug.Log("Delay run"+EchoDistance);
        instantiatedEchoSource = Instantiate(EchoSource, contact.point.normalized, transform.rotation);
        Destroy(instantiatedEchoSource, 0.5f);
    }

}
