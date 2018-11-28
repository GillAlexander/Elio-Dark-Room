using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchElioAndWin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Debug.Log("You found Elio! You won!");
    }
    }
