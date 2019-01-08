using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElioAndPlayerDiffirentLocations : MonoBehaviour {

    public GameObject[] SpawnSpots;
    int spawnNumber;
    public GameObject gameobjectThatContainsElioAndPlayer;
    void Start () {

        SpawnSpots = GameObject.FindGameObjectsWithTag("SpawnSpot");
        spawnNumber = Random.Range(0, SpawnSpots.Length);
        gameobjectThatContainsElioAndPlayer.transform.position = SpawnSpots[spawnNumber].transform.position;
    }
}
