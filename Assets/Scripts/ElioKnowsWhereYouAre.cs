﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioKnowsWhereYouAre : MonoBehaviour {
    //public Transform Other;
    public GameObject elio;
    public GameObject player;
    //Collider elioRadar;
	void Start () {
        //elioRadar = this.GetComponent<SphereCollider>();

	}
	void checkDistance()
{
        if (elio){
            float Distance = Vector3.Distance(elio.transform.position, player.transform.position);
            //print("Distance to other: " + Distance);

            if (Distance <= 10)
            {
                Debug.Log("You are less than 10 from me");
                Debug.Log("You found me");
            }
            else if (Distance <= 30 )
            {
                Debug.Log("You are Less than 30 from me");
            }
            else
            {
                Debug.Log("You are far away");
            }
        }
    }
	void Update () {
        checkDistance();
        }









    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Far")
    //    {
    //        Debug.Log("You are far away");
    //    }
    //    if (collision.gameObject.name == "Middle")
    //    {
    //        Debug.Log("You halfway to Elio");
    //    }
    //    if (collision.gameObject.name == "Close")
    //    {
    //        Debug.Log("You are close to Elio");
    //    }
    //    if ((collision.collider.name == "Far"))
    //    {

    //    }
        
    //}
}
