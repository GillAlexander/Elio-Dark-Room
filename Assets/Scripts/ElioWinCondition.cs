using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioWinCondition : MonoBehaviour
{
    public GameObject elio;
    public GameObject player;
    public static bool foundElio;
    public GameObject[] ElioHidingSpot;
    float distance;
    float passedTime;
    private void Start()
    {
        //foundElio = false;
    }

    private void Update()
    {

        

        passedTime += Time.deltaTime;

        if (foundElio == true&& passedTime >=5)
        {
            Debug.Log(foundElio);
            StartCoroutine(elioFoundReset());
        }
    }

    private void OnTriggerEnter(Collider spheres)
    {
        

        if (spheres.gameObject.name == ("Player") && passedTime>=5)
        {
            Debug.Log("You found Elio! You won!");
            foundElio = true;
            PlayerNoise.foundElio = true;
                       
            passedTime = 0;
            //Debug.Log(passedTime);
        }

        

    }

    IEnumerator elioFoundReset()
    {
        
        Debug.Log("elioFoundResetActivated");
        yield return new WaitForSeconds(4);
        foundElio = false;
        Debug.Log("foundElioResetCompleted");
        
    }

}
//först hittar nytt randomiserat gömställe.
//kolla sen ifall det är tillräckligt långt bort från spelaren. 

//current/active hidingspot. 
//while distance to player (meter)
//randomisera ny hiding spot
//while distance längre än 50 m = true