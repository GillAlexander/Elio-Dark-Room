﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllElioMeshScript : MonoBehaviour
{
    public GameObject elio;
    public GameObject player;
    bool foundElio = false;
    //public GameObject[] ElioHidingSpot;
    public GameObject[] Area1HidingSpots;
    public GameObject[] Area2HidingSpots;
    public GameObject[] Area3HidingSpots;
    public GameObject[] Area4HidingSpots;
    public NavMeshAgent elioAgent;

    static Vector3 elioHidingNumber;

    int playerHasTouchedElio;
    float hidingAreaNumber;
    float distance;

    void Start()
    {
        elioAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (InputManager.YButton())
        {
            hidingAreaNumber++;
            Debug.Log(hidingAreaNumber);
        }
    }
    private void OnCollisionEnter(Collision spheres)
    {
        if (spheres.gameObject.name == ("Player"))
        {
            while (true)
            {

            }
            if (hidingAreaNumber == 1)
            {
                elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
                elioAgent.SetDestination(elioHidingNumber);
                
            }
            else if (hidingAreaNumber == 2)
            {
                elioHidingNumber = Area2HidingSpots[Random.Range(0, Area2HidingSpots.Length)].transform.position;
                elioAgent.SetDestination(elioHidingNumber);
                
            }
            else if(hidingAreaNumber == 3)
            {
                elioHidingNumber = Area3HidingSpots[Random.Range(0, Area3HidingSpots.Length)].transform.position;
                elioAgent.SetDestination(elioHidingNumber);
            }
            else if (hidingAreaNumber == 4)
            {
                elioHidingNumber = Area4HidingSpots[Random.Range(0, Area4HidingSpots.Length)].transform.position;
                elioAgent.SetDestination(elioHidingNumber);
            }
        }
    }


    private void checkDistance()
    {
        distance = Vector3.Distance(elio.transform.position, player.transform.position);
    }
}

