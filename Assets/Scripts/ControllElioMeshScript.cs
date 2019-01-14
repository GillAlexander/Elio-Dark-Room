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
    public float timeForElioToSitDown;
    public float timeForElioToMoveToNewHidingPlace;
    public float timeForElio = 5;
    bool elioHasAHidingSpot = false;


    void Start()
    {
        elioAgent = GetComponent<NavMeshAgent>();
        timeUntilYouCanFindElio = 5;
        //Transform[] hidingPlaces = new Transform[HidingSpots.Length];

        HidingSpots = GameObject.FindGameObjectsWithTag("HidingSpot");

    }

    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("Lasttrymenu");
        }
        timeUntilYouCanFindElio += Time.smoothDeltaTime;
        timeUntilGameOver += Time.smoothDeltaTime;
        timeForElioToMoveToNewHidingPlace += Time.smoothDeltaTime;

        CheckDistance();
        ElioAnimations();
        if (timeUntilGameOver <= timeForElio)
        {

            ElioAI();
            
            if (distanceBetweenElioAndHidingSpot < 2)
            {
                elioAgent.GetComponent<NavMeshAgent>().speed = 0;
                elioAgent.GetComponent<NavMeshAgent>().acceleration = 0;
                anim.SetBool("Wait", true);
                timeForElioToSitDown += Time.smoothDeltaTime;
                if (timeForElioToSitDown > 1 && anim.GetBool("Wait") == true)
                {
                    timeForElioToSitDown = 0;
                    anim.SetFloat("Speed", Mathf.Abs(elioAgent.speed));
                }
                ElioSounds.isMoving = false;
            }
            else
            {
                ElioSounds.isMoving = true;
                anim.SetBool("Wait", false);
                elioAgent.GetComponent<NavMeshAgent>().speed = 4;
                elioAgent.GetComponent<NavMeshAgent>().acceleration = 2;
            }
            if (distanceBetweenElioAndPlayer >= 60)
            {
                elioAgent.GetComponent<NavMeshAgent>().speed = 4;
                elioAgent.GetComponent<NavMeshAgent>().acceleration = 2;
                elioAgent.SetDestination(player.transform.position);
            }
        }
        
        if (timeUntilGameOver > timeForElio)
        {
            ElioAI();
            anim.SetFloat("Speed", Mathf.Abs(elioAgent.speed));
            anim.SetBool("Wait", false);
            elioAgent.SetDestination(player.transform.position);
            elioAgent.speed = 4f;
            elioAgent.acceleration = 1;
            if (distanceBetweenElioAndPlayer < 10)
            {
                
                timeToQuitGame += Time.smoothDeltaTime;

                ElioSounds.gameOver++;
                if (timeToQuitGame > 4.5f)
                {
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
                    //timeForElioToMoveToNewHidingPlace += Time.smoothDeltaTime;
                    if (timeForElioToMoveToNewHidingPlace > 1)
                    {
                        if (distanceBetweenElioAndPlayer <= 58)
                        {
                            setElioDestinationToHidingSpot();
                        }
                    }

                }

                if (distanceBetweenElioAndPlayer <= 5)
                {

                    if (timeUntilYouCanFindElio > 5)
                    {
                        if (ElioSounds.gameOver == 0 && timeUntilGameOver > 5)
                            ElioSounds.elioFound = true;

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
                        timeUntilYouCanFindElio = 0;
                    }
                }
            }
        }
       
    }

    private void CheckDistance()
    {
        distanceBetweenElioAndPlayer = Vector3.Distance(elio.transform.position, player.transform.position);
        distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
        distanceBetweenElioAndHidingSpot = Vector3.Distance(elio.transform.position, elioHidingNumber);
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
    private void ElioAnimations()
    {
        if (ElioSounds.isMoving == false)
        {
            anim.SetFloat("Speed", Mathf.Abs(elioAgent.speed));
            //anim.Play("Armature|Idle");
        }
        else if (ElioSounds.isMoving = true && elioAgent.speed > 0 && elioAgent.speed <= 4)
        {
            anim.SetFloat("Speed", Mathf.Abs(elioAgent.speed));
            //anim.Play("Armature|Walking");
        }
        else
        {
            anim.SetFloat("Speed", Mathf.Abs(elioAgent.speed));
            //anim.Play("Armature|Runing");
        }
    }
}