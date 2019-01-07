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
    public float timeUntilGameOver;
    public float timeUntilElioDecidesToChangeHidingSpotArea;
    public float timeUntilYouCanFindElio;
    bool elioHasAHidingSpot = false;
    //if elio is hiding = true, if not hiding = false       -- När Elio rör sig:  ElioSounds.isMoving = true;
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
        timeUntilElioDecidesToChangeHidingSpotArea += Time.smoothDeltaTime;
        timeUntilYouCanFindElio += Time.smoothDeltaTime;
        timeUntilGameOver += Time.smoothDeltaTime;

        //if (Vector3.Distance(elio.transform.position, player.transform.position) > 30)
        //{
        //    elioAgent.SetDestination(player.transform.position - (elioPlayerDistance * 30));
        //}
    }
    private void ElioAI()
    {
        if (timeUntilElioDecidesToChangeHidingSpotArea >= 20)
        {
            timeUntilElioDecidesToChangeHidingSpotArea = 0;
            hidingAreaNumber = Random.Range(1, 5);
            Debug.Log(hidingAreaNumber);
        }
        if (distanceBetweenElioAndPlayer >= 60)
        {
            elioAgent.GetComponent<NavMeshAgent>().speed = 4;
            elioAgent.GetComponent<NavMeshAgent>().acceleration = 4;
            elioAgent.SetDestination(player.transform.position);
        }
        else if (distanceBetweenElioAndPlayer < 60)
        {
            elioAgent.GetComponent<NavMeshAgent>().speed = 0;
            elioAgent.GetComponent<NavMeshAgent>().acceleration = 0;

            if (distanceBetweenElioAndPlayer <= 58)
            {
                elioAgent.GetComponent<NavMeshAgent>().speed = 4;
                elioAgent.GetComponent<NavMeshAgent>().acceleration = 4;

                if (elioHasAHidingSpot)
                {
                    if (distanceBetweenElioAndPlayer <= 58)
                    {
                        elioAgent.SetDestination(elioHidingNumber);
                        //(elio -- hidingspot)
                        if (true)
                        {
                            //if elio near hiding spot = true
                        }
                    }
                }
                if (distanceBetweenElioAndPlayer <= 18)
                {
                    if (timeUntilYouCanFindElio > 5)
                    {
                        timeUntilYouCanFindElio = 0;

                        if (hidingAreaNumber == 1)
                        {
                            elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
                            distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
                            while (distanceBetweenPlayerAndHidingSpot <= 30)
                            {
                                elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
                                distanceBetweenPlayerAndHidingSpot = Vector3.Distance(player.transform.position, elioHidingNumber);
                            }
                            //(distance between elio and hiding spot)
                            //if elio is near hidning = true
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