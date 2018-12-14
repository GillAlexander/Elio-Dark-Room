using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour {
    ElioWinCondition Eliofound;
    int gameScore = 0;

    private void Start()
    {
       //Eliofound = GameObject.Find("Elio").GetComponent<ElioWinCondition>();
    }



    void Update () {

     
        

        Debug.Log("pointSystemUpdate");

        if (ElioWinCondition.foundElio == true)
        {
            gameScore = gameScore + 1;
            Debug.Log("Gamescore: "+gameScore);
            Debug.Log("Elio found true");
        }
        else if (ElioWinCondition.foundElio == false)
        {
            Debug.Log("Elio found false");
        }
	}
}
