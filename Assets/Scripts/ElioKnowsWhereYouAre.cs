using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioKnowsWhereYouAre : MonoBehaviour {

    Collider elioRadar;
	void Start () {
        elioRadar = this.GetComponent<SphereCollider>();
	}
	
	void Update () {
        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Far")
        {
            Debug.Log("You are far away");
        }
        if (collision.gameObject.name == "Middle")
        {
            Debug.Log("You halfway to Elio");
        }
        if (collision.gameObject.name == "Close")
        {
            Debug.Log("You are close to Elio");
        }
        if ((collision.collider.name == "Far"))
        {

        }
        
    }
}
