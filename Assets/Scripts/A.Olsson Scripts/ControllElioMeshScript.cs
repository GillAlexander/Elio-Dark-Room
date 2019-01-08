using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ControllElioMeshScript : MonoBehaviour
{
    public GameObject elio;
    public GameObject player;
    public GameObject[] HidingSpots;
    public ArrayList hidingPlaces;
    public NavMeshAgent elioAgent;
    static Vector3 elioHidingNumber;
    int playerHasTouchedElio;
    Vector3 elioPlayerDistance;
    float distanceBetweenElioAndPlayer;
    float distanceBetweenPlayerAndHidingSpot;
    float distanceBetweenElioAndHidingSpot;
    public float timeUntilGameOver;
    public float timeUntilYouCanFindElio;
    bool elioHasAHidingSpot = false;
    
    void Start()
    {
        elioAgent = GetComponent<NavMeshAgent>();

        //Transform[] hidingPlaces = new Transform[HidingSpots.Length];

        HidingSpots = GameObject.FindGameObjectsWithTag("HidingSpot");
        for (int i = 0; i < HidingSpots.Length ; i++)
        {
            //hidingPlaces[i] = HidingSpots[i].GetComponent<Transform>().position;
        }
        
    }

    void Update()
    {
        CheckDistance();
        ElioAI();
        timeUntilYouCanFindElio += Time.smoothDeltaTime;
        timeUntilGameOver += Time.smoothDeltaTime;

        distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
        distanceBetweenElioAndHidingSpot = Vector3.Distance(elio.transform.position, elioHidingNumber);
        Debug.Log(distanceBetweenElioAndPlayer);
        if (distanceBetweenElioAndHidingSpot < 3)
            ElioSounds.isMoving = false;
        else
            ElioSounds.isMoving = true;
    }
    private void ElioAI()
    {
        if (distanceBetweenElioAndPlayer >= 60)
        {
            elioAgent.GetComponent<NavMeshAgent>().speed = 8;
            elioAgent.GetComponent<NavMeshAgent>().acceleration = 4;
            elioAgent.SetDestination(player.transform.position);
        }
        else if (distanceBetweenElioAndPlayer < 60)
        {
            elioAgent.GetComponent<NavMeshAgent>().speed = 0;
            elioAgent.GetComponent<NavMeshAgent>().acceleration = 0;

            if (distanceBetweenElioAndPlayer <= 58)
            {
                elioAgent.GetComponent<NavMeshAgent>().speed = 8;
                elioAgent.GetComponent<NavMeshAgent>().acceleration = 4;

                if (elioHasAHidingSpot)
                {
                    if (distanceBetweenElioAndPlayer <= 58)
                    {
                        elioAgent.SetDestination(elioHidingNumber);
                    }
                }

                if (distanceBetweenElioAndPlayer <= 5)
                {
                    if (timeUntilYouCanFindElio > 2)
                    {   timeUntilYouCanFindElio = 0;
                        
                        elioHidingNumber = HidingSpots[Random.Range(0, HidingSpots.Length)].transform.position;

                        int safety = 0;

                        do
                        {
                            elioHidingNumber = HidingSpots[Random.Range(0, HidingSpots.Length)].transform.position;
                            distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);

                            safety++;
                            if (safety >= 100)
                            {
                                Debug.Log("bröt mer än 100");
                                break;
                            }

                        } while (distanceBetweenPlayerAndHidingSpot < 10 || distanceBetweenPlayerAndHidingSpot >= 80);

                        elioAgent.SetDestination(elioHidingNumber);
                        elioHasAHidingSpot = true;
                        
                    }
                }
            }
        }
    }

    private void CheckDistance()
    {
        distanceBetweenElioAndPlayer = Vector3.Distance(elio.transform.position, player.transform.position);
    }
}

/*
                        else if (hidingAreaNumber == 2)
                        {
                            elioHidingNumber = Area2HidingSpots[Random.Range(0, Area2HidingSpots.Length)].transform.position;
                            distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
                            while (distanceBetweenPlayerAndHidingSpot <= 30)
                            {
                                elioHidingNumber = Area2HidingSpots[Random.Range(0, Area2HidingSpots.Length)].transform.position;
                                distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
                            }
                            elioAgent.SetDestination(elioHidingNumber);
                            elioHasAHidingSpot = true;
                        }
                        else if (hidingAreaNumber == 3)
                        {
                            elioHidingNumber = Area3HidingSpots[Random.Range(0, Area3HidingSpots.Length)].transform.position;
                            distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
                            while (distanceBetweenPlayerAndHidingSpot <= 30)
                            {
                                elioHidingNumber = Area3HidingSpots[Random.Range(0, Area3HidingSpots.Length)].transform.position;
                                distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
                            }
                            elioAgent.SetDestination(elioHidingNumber);
                            elioHasAHidingSpot = true;
                        }
                        else if (hidingAreaNumber == 4)
                        {
                            elioHidingNumber = Area4HidingSpots[Random.Range(0, Area4HidingSpots.Length)].transform.position;
                            distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
                            while (distanceBetweenPlayerAndHidingSpot <= 30)
                            {
                                elioHidingNumber = Area4HidingSpots[Random.Range(0, Area4HidingSpots.Length)].transform.position;
                                distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
                            }
                            elioAgent.SetDestination(elioHidingNumber);
                            elioHasAHidingSpot = true;
                        }
                        */