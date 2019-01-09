using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class ControllElioMeshScript : MonoBehaviour
{
    public Animator anim;
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
    public float timeToQuitGame;
    bool elioHasAHidingSpot = false;
    
    
    void Start()
    {
        elioAgent = GetComponent<NavMeshAgent>();

        //Transform[] hidingPlaces = new Transform[HidingSpots.Length];

        HidingSpots = GameObject.FindGameObjectsWithTag("HidingSpot");
        
    }

    void Update()
    {
        CheckDistance();
        ElioAI();
        timeUntilYouCanFindElio += Time.smoothDeltaTime;
        timeUntilGameOver += Time.smoothDeltaTime;

        distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
        distanceBetweenElioAndHidingSpot = Vector3.Distance(elio.transform.position, elioHidingNumber);
        Debug.Log(elioAgent.speed);
        if (distanceBetweenElioAndHidingSpot < 5)
        {
            ElioSounds.isMoving = false;
            elioAgent.GetComponent<NavMeshAgent>().speed = 0;
            elioAgent.GetComponent<NavMeshAgent>().acceleration = 0;
        }
        else
        {
            ElioSounds.isMoving = true;
            elioAgent.GetComponent<NavMeshAgent>().speed = 4;
            elioAgent.GetComponent<NavMeshAgent>().acceleration = 2;
        }

        if (ElioSounds.isMoving == false)
        {
            anim.SetFloat("Speed", Mathf.Abs(elioAgent.speed));
            //anim.Play("Armature|Idle");
        }
        else if(ElioSounds.isMoving = true && elioAgent.speed > 0 && elioAgent.speed <= 4)
        {
            anim.SetFloat("Speed", Mathf.Abs(elioAgent.speed));
            //anim.Play("Armature|Walking");
        }
        else
        {
            anim.SetFloat("Speed", Mathf.Abs(elioAgent.speed));
            //anim.Play("Armature|Runing");
        }

        if (timeUntilGameOver >= 180)
        {
            elioAgent.SetDestination(player.transform.position);
            if (distanceBetweenElioAndPlayer < 10)
            {
                elioAgent.speed = 2.5f;
                elioAgent.acceleration = 1;
                elioAgent.stoppingDistance = 5;
                timeToQuitGame += Time.smoothDeltaTime;
                if (timeToQuitGame > 3)//Så lång tid det tar att säga hej då replik
                {
                    //Game over
                    SceneManager.LoadScene("Lasttrymenu");
                }
            }
        }
        
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
            elioAgent.GetComponent<NavMeshAgent>().speed = 4;
            elioAgent.GetComponent<NavMeshAgent>().acceleration = 0;

            if (distanceBetweenElioAndPlayer <= 58)
            {
                elioAgent.GetComponent<NavMeshAgent>().speed = 8;
                elioAgent.GetComponent<NavMeshAgent>().acceleration = 4;

                if (elioHasAHidingSpot)
                {
                    if (distanceBetweenElioAndPlayer <= 58)
                    {
                        setElioDestinationToHidingSpot();
                    }
                }

                if (distanceBetweenElioAndPlayer <= 5)
                {
                    if (timeUntilYouCanFindElio > 3)
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
                        
                        setElioDestinationToHidingSpot();
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
    private void setElioSpeed()
    {
        elioAgent.GetComponent<NavMeshAgent>().speed = 8;
        elioAgent.GetComponent<NavMeshAgent>().acceleration = 4;
    }
    private void elioSpeedIsZero()
    {
        elioAgent.GetComponent<NavMeshAgent>().speed = 0;
        elioAgent.GetComponent<NavMeshAgent>().acceleration = 0;
    }
    private void setElioDestinationToHidingSpot()
    {
        elioAgent.SetDestination(elioHidingNumber);
    }
}