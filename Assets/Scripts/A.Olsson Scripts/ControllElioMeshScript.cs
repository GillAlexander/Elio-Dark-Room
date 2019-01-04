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
    float playerHidingSpotDistance;
    public float time;
    public float timeUntilYouCanFindElio;
    bool elioHasAHidingSpot = false;
    void Start()
    {
        elioAgent = GetComponent<NavMeshAgent>();
        //player.GetComponent<Playercontroller>().enabled = false;
    }

    void Update()
    {
        Debug.Log(Vector3.Distance(elio.transform.position, player.transform.position));
        CheckDistance();
        //YouFoundElio();
        ElioAI();
        time += Time.smoothDeltaTime;
        timeUntilYouCanFindElio += Time.smoothDeltaTime;

        //if (Vector3.Distance(elio.transform.position, player.transform.position) > 30)
        //{
        //    elioAgent.SetDestination(player.transform.position - (elioPlayerDistance * 30));
        //}
    }
    private void ElioAI()
    {
        if (time >= 20)
        {   time = 0;
            hidingAreaNumber = Random.Range(1, 5);
            Debug.Log(hidingAreaNumber);
        }
        if (Vector3.Distance(elio.transform.position, player.transform.position) >= 60)
        {
            elioAgent.GetComponent<NavMeshAgent>().isStopped = false;
            elioAgent.SetDestination(player.transform.position);
        }
        else if(Vector3.Distance(elio.transform.position, player.transform.position) < 60)
        {
            elioAgent.GetComponent<NavMeshAgent>().isStopped = true;
            elioAgent.velocity = Vector3.zero;
            if (elioAgent.velocity == Vector3.zero)
            {
                elioAgent.GetComponent<NavMeshAgent>().isStopped = false;
                if (elioHasAHidingSpot)
                {
                    elioAgent.GetComponent<NavMeshAgent>().isStopped = false;
                    elioAgent.SetDestination(elioHidingNumber);
                    Debug.Log("Elio har redan ett gömställe och går tillbaka till det.");
                }
                else
                {
                    if (Vector3.Distance(elio.transform.position, player.transform.position) <= 20)
                    {
                        if (timeUntilYouCanFindElio > 5)
                        {
                            timeUntilYouCanFindElio = 0;

                            if (hidingAreaNumber == 1)
                            {
                                elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
                                playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
                                while (playerHidingSpotDistance <= 30)
                                {
                                    elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
                                    playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
                                }
                                elioAgent.SetDestination(elioHidingNumber);
                                elioHasAHidingSpot = true;
                                Debug.Log("Elio har fått ett nytt gömställe");
                            }
                            else if (hidingAreaNumber == 2)
                            {
                                elioHidingNumber = Area2HidingSpots[Random.Range(0, Area2HidingSpots.Length)].transform.position;
                                Debug.Log(elioHidingNumber);
                                playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
                                while (playerHidingSpotDistance <= 30)
                                {
                                    elioHidingNumber = Area2HidingSpots[Random.Range(0, Area2HidingSpots.Length)].transform.position;
                                    playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
                                }
                                elioAgent.SetDestination(elioHidingNumber);
                                elioHasAHidingSpot = true;
                            }
                            else if (hidingAreaNumber == 3)
                            {
                                elioHidingNumber = Area3HidingSpots[Random.Range(0, Area3HidingSpots.Length)].transform.position;
                                playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
                                while (playerHidingSpotDistance <= 30)
                                {
                                    elioHidingNumber = Area3HidingSpots[Random.Range(0, Area3HidingSpots.Length)].transform.position;
                                    playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
                                }
                                Debug.Log(elioHidingNumber);
                                elioAgent.SetDestination(elioHidingNumber);
                                elioHasAHidingSpot = true;
                            }
                            else if (hidingAreaNumber == 4)
                            {
                                elioHidingNumber = Area4HidingSpots[Random.Range(0, Area4HidingSpots.Length)].transform.position;
                                playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
                                while (playerHidingSpotDistance <= 30)
                                {
                                    elioHidingNumber = Area4HidingSpots[Random.Range(0, Area4HidingSpots.Length)].transform.position;
                                    playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
                                }
                                Debug.Log(elioHidingNumber);
                                elioAgent.SetDestination(elioHidingNumber);
                                elioHasAHidingSpot = true;
                            }
                        }
                    }
                }
            }
        }
    }

    //private void YouFoundElio()
    //{
    //    if (time >= 20)
    //    {
    //        time = 0;
    //        hidingAreaNumber = Random.Range(1, 5);
    //        Debug.Log(hidingAreaNumber);
    //    }
    //    if (distanceBetweenElioAndPlayer < 15)
    //    {
    //        if (timeUntilYouCanFindElio > 5)
    //        {   timeUntilYouCanFindElio = 0;

    //            if (hidingAreaNumber == 1)
    //            {
    //                elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
    //                playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
    //                while (playerHidingSpotDistance <= 30)
    //                {
    //                    elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
    //                    playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
    //                }
    //                Debug.Log(elioHidingNumber);
    //                elioAgent.SetDestination(elioHidingNumber);
    //            }
    //            else if (hidingAreaNumber == 2)
    //            {
    //                elioHidingNumber = Area2HidingSpots[Random.Range(0, Area2HidingSpots.Length)].transform.position;
    //                Debug.Log(elioHidingNumber);
    //                playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
    //                while (playerHidingSpotDistance <= 30)
    //                {
    //                    elioHidingNumber = Area2HidingSpots[Random.Range(0, Area2HidingSpots.Length)].transform.position;
    //                    playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
    //                }
    //                elioAgent.SetDestination(elioHidingNumber);
    //            }
    //            else if (hidingAreaNumber == 3)
    //            {
    //                elioHidingNumber = Area3HidingSpots[Random.Range(0, Area3HidingSpots.Length)].transform.position;
    //                playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
    //                while (playerHidingSpotDistance <= 30)
    //                {
    //                    elioHidingNumber = Area3HidingSpots[Random.Range(0, Area3HidingSpots.Length)].transform.position;
    //                    playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
    //                }
    //                Debug.Log(elioHidingNumber);
    //                elioAgent.SetDestination(elioHidingNumber);
    //            }
    //            else if (hidingAreaNumber == 4)
    //            {
    //                elioHidingNumber = Area4HidingSpots[Random.Range(0, Area4HidingSpots.Length)].transform.position;
    //                playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
    //                while (playerHidingSpotDistance <= 30)
    //                {
    //                    elioHidingNumber = Area4HidingSpots[Random.Range(0, Area4HidingSpots.Length)].transform.position;
    //                    playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
    //                }
    //                Debug.Log(elioHidingNumber);
    //                elioAgent.SetDestination(elioHidingNumber);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        playerFoundElio = false;
    //    }
    //}

    private void CheckDistance()
    {
        distanceBetweenElioAndPlayer = Vector3.Distance(elio.transform.position, player.transform.position);
        elioPlayerDistance = (player.transform.position - elio.transform.position);
        elioPlayerDistance.Normalize();
    }

}



//    /*
//     Elio springer och gömmer sig-(klar)
//     Elio springer till ny posision när du hittar han-(klar)
//     Elio's områdespositioner är timer kopplade-(klar)
//     Elio byter område efter en viss tid-(klar)
//     Elio kommer ha en övergångsfas till sitt nya område?
//     Elio vet alltid hur långt bort spelaren befinner sig-(klar)
//     Elio ropar mot spelaren när spelaren går förlångt bort (klar)
//     Elio ser till att spelaren inte går förlångt bort genom att göra ljud ifrån sig som spelaren hör. (klar)
//     Elio svarar inte på spelarens visselljud när spelaren är inom en viss distans från Elio / göra det svårare för spelaren att hitta Elio (elio fnittrar)
//     Elio kan inte få ett gömställe nära spelaren när han blir funnen. (klar)
//    */