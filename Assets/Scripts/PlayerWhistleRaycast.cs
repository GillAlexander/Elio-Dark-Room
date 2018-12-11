using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWhistleRaycast : MonoBehaviour {

    public GameObject EchoSource;
    private GameObject instantiatedEchoSource;

    public float WhistleRange;
    float numberOfEchoes;
    public float maxEchoes;
    public float echoCooldown;
    float time = 0;

    float EchoDistance;
    RaycastHit contact;
    
    void Start () {
      
	}
	

	void Update () {
        bool ElioWhistle = Input.GetButton("Whistle");
        time += Time.deltaTime;
        if (ElioWhistle && time >= echoCooldown)
        {

            for(int i=0; i<3; i++) {

                float PlayerRayX = WhistleRange * Mathf.Cos(120 - (30 * i));
                float PlayerRayY = WhistleRange * Mathf.Sin(120 - (30 * i));

                if (Physics.Raycast(transform.position, transform.TransformDirection(PlayerRayX, 0, PlayerRayY), out contact, WhistleRange))
                {
                    EchoDistance = contact.distance;

                    instantiatedEchoSource = (GameObject)Instantiate(EchoSource, contact.point.normalized, transform.rotation);

                    Debug.Log("Player sees something: " + EchoDistance);
                    Debug.DrawRay(transform.position, contact.point - transform.position, Color.red);

                    Destroy(instantiatedEchoSource, 1);

                    
                }
                
            }
            time = 0;
        }
    }

}
