using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour {
    float delayTimer;
    //int gameScore = 0;

    private void Start()
    {
       //Eliofound = GameObject.Find("Elio").GetComponent<ElioWinCondition>();
    }



    void Update () {

        delayTimer += Time.deltaTime;
        

        Debug.Log("pointSystemUpdate");
/*
        if (ElioWinCondition.foundElio == true && delayTimer>=2)
        {
           
            gameScore = gameScore + 1;
            Debug.Log("Gamescore: " + gameScore);
            Debug.Log("Elio found true");

            delayTimer = 0;
        }
        else if (ElioWinCondition.foundElio == false)
        {
            Debug.Log("Elio found false");
        }*/
	}

    IEnumerator ScoreDelay()
    {
      yield return new WaitForSeconds(3);
        StartCoroutine(ScoreDelay());
    }
}
