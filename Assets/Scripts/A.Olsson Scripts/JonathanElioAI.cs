using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonathanElioAI : MonoBehaviour {

    public Transform player;
    
	void Update (){
	}
    private void OnTriggerStay(Collider spheres){
        if (spheres.gameObject.name == "Far")
        {
            Debug.Log("You are far away");
        }
        if (spheres.gameObject.name == "Middle")
        {
            Debug.Log("You halfway to Elio");
        }
        if (spheres.gameObject.name == "Close")
        {
            Debug.Log("You are close to Elio");
        }
    }
   
    private void OnTriggerExit(Collider spheres)
    {
        if (spheres.gameObject.name == "Far")
        {
            Debug.Log("You are leaving the most far away sphear");
        }
        if (spheres.gameObject.name == ("Middle"))
        {
            Debug.Log("You are leaving the middle sphear");
        }
        if (spheres.gameObject.name == ("Close"))
        {
            Debug.Log("You are leaving the closest sphear");
        }
        //Win Condition
        
    }
}
