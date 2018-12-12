using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioWinCondition : MonoBehaviour {
    public GameObject elio;
    public GameObject player;
    bool foundElio = false;
    public GameObject[] ElioHidingSpot;
    float distance;

    private void OnTriggerEnter(Collider spheres)
    {
        if (spheres.gameObject.name == ("Player"))
        {
            //Debug.Log("You found Elio! You won!");
            foundElio = true;
            PlayerNoise.foundElio = true;
            distance = Vector3.Distance(elio.transform.position, player.transform.position);

            while (foundElio && distance < 10)
            {
                
                elio.transform.position =
                ElioHidingSpot[Random.Range(0, ElioHidingSpot.Length)].transform.position;
                distance = Vector3.Distance(elio.transform.position, player.transform.position);
                //Debug.Log(distance);
            }
            foundElio = false;
            //void CheckDistance(){
            //    if (elio){
            //        float Distance = Vector3.Distance(elio.transform.position, player.transform.position);
            //        //print("Distance to other: " + Distance);
            //        if (Distance <= 10){
            //            Debug.Log("You are less than 10 from me");
            //            Debug.Log("You found me");
            //        }
            //        else if (Distance <= 30){
            //            Debug.Log("You are Less than 30 from me");
            //        }
            //        else{
            //            Debug.Log("You are far away");
            //        }
            //    }
            //}
            //current/active hidingspot. 
            //while distance to player (meter)
            //randomisera ny hiding spot
            //while distance längre än 50 m = true

        }
        //först hittar nytt randomiserat gömställe.
        //kolla sen ifall det är tillräckligt långt bort från spelaren. 
    }
}
