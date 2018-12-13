using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllElioMeshScript : MonoBehaviour {

    public GameObject elio;
    public GameObject player;
    bool foundElio = false;
    public GameObject[] ElioHidingSpot;
    public NavMeshAgent elioAgent;
    Vector3 elioVector;
    void Start () {
		
	}
	
	void Update () {

        if (InputManager.ClapButton())
        {

            //Vector3 elioVector =  new Vector3(
            //        ElioHidingSpot[Random.Range(0, ElioHidingSpot.Length)].transform.position.x, 
            //        0f, 
            //        ElioHidingSpot[Random.Range(0, ElioHidingSpot.Length)].transform.position.y
            //                                );

            Vector3 elioVector = new Vector3(
                   ElioHidingSpot[0].transform.position.x,
                   0f,
                   ElioHidingSpot[0].transform.position.y
                                           );

            //foundElio = true;
            elio.transform.position =
                ElioHidingSpot[Random.Range(0, ElioHidingSpot.Length)].transform.position;
            elioAgent.destination(elioVector);
        }
	}
}
