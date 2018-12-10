using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonathanElioAI : MonoBehaviour {

    public Transform player;
    public GameObject Elio;
    public GameObject ElioHidingSpot1, ElioHidingSpot2, ElioHidingSpot3;
	void Update (){
        if (InputManager.XButton())
        {
            Elio.transform.position = ElioHidingSpot1.transform.position;
        }
        if (InputManager.BButton())
        {
            Elio.transform.position = ElioHidingSpot2.transform.position;
        }
        if (InputManager.YButton())
        {
            Elio.transform.position = ElioHidingSpot3.transform.position;
        }
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
    }
}
