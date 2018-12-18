using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JonathanElioWinCondition : MonoBehaviour
{
    public GameObject elio;
    public GameObject player;
    bool foundElio = false;
    public GameObject[] ElioHidingSpot;
    float distance;
    public NavMeshAgent elioAgentTEST;
    static Vector3 elioHidingNumber;
    static bool elioWasFoundNowElioWillMove = false;

    private void Start()
    {
        elioAgentTEST = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //CheckDistance();
        //Debug.Log(distance);
    }
    private void OnTriggerEnter(Collider spheres)
    {
        if (spheres.gameObject.name == ("Player"))
        {
            Debug.Log("You found Elio! You won!");
            elioWasFoundNowElioWillMove = true;
            foundElio = true;
            PlayerNoise.foundElio = true;


            //while (foundElio && distance < 10)
            //{


            //    //Debug.Log(distance);
            //}
            foundElio = false;


            //current/active hidingspot. 
            //while distance to player (meter)
            //randomisera ny hiding spot
            //while distance längre än 50 m = true

        }
        
        //först hittar nytt randomiserat gömställe.
        //kolla sen ifall det är tillräckligt långt bort från spelaren. 
    }

    //private void CheckDistance()
    //{
    //    if (elio)
    //    {
    //        float Distance = Vector3.Distance(elio.transform.position, player.transform.position);
    //        //print("Distance to other: " + Distance);
    //        if (Distance <= 10)
    //        {
    //            Debug.Log("You are less than 10 from me");
    //            Debug.Log("You found me");
    //        }
    //        else if (Distance <= 30)
    //        {
    //            Debug.Log("You are Less than 30 from me");
    //        }
    //        else
    //        {
    //            Debug.Log("You are far away");
    //        }
    //    }
    //}
}
