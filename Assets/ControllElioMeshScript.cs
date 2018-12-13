using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllElioMeshScript : MonoBehaviour {
    //public GameObject elio;
    //public GameObject player;
    bool foundElio = false;
    public GameObject[] ElioHidingSpot;
    public NavMeshAgent elioAgent;
    Vector3 elioVector;
    public Transform target;
    public Camera cam;

    void Start () {
        elioAgent = GetComponent<NavMeshAgent>();
    }
	
	void Update () {
        if (InputManager.ClapButton())
        {
            Vector3 elioHidingNumber = ElioHidingSpot[Random.Range(0, ElioHidingSpot.Length)].transform.position;
            
            elioAgent.SetDestination(elioHidingNumber);


            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
            //    elioAgent.SetDestination(hit.point);
            //}
        }

    }
}

//Vector3 elioVector = new Vector3(
//        ElioHidingSpot[Random.Range(0, ElioHidingSpot.Length)].transform.position.x,
//        0f,
//        ElioHidingSpot[Random.Range(0, ElioHidingSpot.Length)].transform.position.y
//                                );


/*
  if (InputManager.ClapButton())
        {
            
            {
                elioAgent.SetDestination(hit.point);
            }
            //Vector3 elioVector =  new Vector3(
            //        ElioHidingSpot[Random.Range(0, ElioHidingSpot.Length)].transform.position.x, 
            //        0f, 
            //        ElioHidingSpot[Random.Range(0, ElioHidingSpot.Length)].transform.position.y
            //                                );

            //Vector3 elioVector = new Vector3(
            //       ElioHidingSpot[0].transform.position.x,
            //       0f,
            //       ElioHidingSpot[0].transform.position.y
            //                               );

            //if (Vector3.Distance(destination, target.position) > 1.0f)
            //{
            //    destination = target.position;
            //    elioAgent.destination = destination;
            //}
            //foundElio = true;
            //elio.transform.position =
            //    ElioHidingSpot[Random.Range(0, ElioHidingSpot.Length)].transform.position;
            //elioAgent.destination(elioVector);
        }
*/
