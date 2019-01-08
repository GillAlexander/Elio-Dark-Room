using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ControllElioMeshScript : MonoBehaviour
{
    public GameObject elio;
    public GameObject player;
    public GameObject[] Area1HidingSpots;
    public GameObject[] Area2HidingSpots;
    public GameObject[] Area3HidingSpots;
    public GameObject[] Area4HidingSpots;
    public NavMeshAgent elioAgent;
    static Vector3 elioHidingNumber;
    int playerHasTouchedElio;
    float hidingAreaNumber = 1;
    Vector3 elioPlayerDistance;
    float distanceBetweenElioAndPlayer;
    float distanceBetweenPlayerAndHidingSpot;
    float distanceBetweenElioAndHidingSpot;
    public float timeUntilGameOver;
    public float timeUntilElioDecidesToChangeHidingSpotArea;
    public float timeUntilYouCanFindElio;
    bool elioHasAHidingSpot = false;

    void Start()
    {
        elioAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        CheckDistance();
        ElioAI();
        timeUntilElioDecidesToChangeHidingSpotArea += Time.smoothDeltaTime;
        timeUntilYouCanFindElio += Time.smoothDeltaTime;
        timeUntilGameOver += Time.smoothDeltaTime;

        distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
        distanceBetweenElioAndHidingSpot = Vector3.Distance(elio.transform.position, elioHidingNumber);

        if (distanceBetweenElioAndHidingSpot < 2)
            ElioSounds.isMoving = false;
        else
            ElioSounds.isMoving = true;
    }
    private void ElioAI()
    {
        if (timeUntilElioDecidesToChangeHidingSpotArea >= 20)
        {
            timeUntilElioDecidesToChangeHidingSpotArea = 0;
            hidingAreaNumber = Random.Range(1, 5);
        }
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
                    if (timeUntilYouCanFindElio > 5)
                    {
                        timeUntilYouCanFindElio = 0;

                        if (hidingAreaNumber == 1)
                        {
                            elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;

                            while (distanceBetweenPlayerAndHidingSpot <= 30)
                            {
                                int safety = 0;
                                elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
                                distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
                                safety++;

                                if (safety >= 100)
                                {
                                    Debug.Log("bröt mindre än 30");
                                }
                            }
                            //bygg om till 1 super array, kolla ifall Elio kan hitta en hiding spot inom viss distance = 100 distans
                            while (distanceBetweenPlayerAndHidingSpot >= 80)
                            {
                                int safety = 0;
                                elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
                                distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
                                safety++;
                                if (safety >= 100)
                                {
                                    Debug.Log("bröt mer än 100");
                                }
                            }
                            elioAgent.SetDestination(elioHidingNumber);
                            elioHasAHidingSpot = true;

                        }
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