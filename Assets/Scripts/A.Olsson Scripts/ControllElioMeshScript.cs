using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ControllElioMeshScript : MonoBehaviour
{
    public GameObject elio;
    public GameObject player;
    bool playerFoundElio = false;
    public GameObject[] Area1HidingSpots;
    public GameObject[] Area2HidingSpots;
    public GameObject[] Area3HidingSpots;
    public GameObject[] Area4HidingSpots;
    public NavMeshAgent elioAgent;
    static Vector3 elioHidingNumber;
    int playerHasTouchedElio;
    float hidingAreaNumber = 1;
    float elioPlayerDistance;
    float playerHidingSpotDistance;
    public float time;
    public float timeUntilYouCanFindElio;
    

    public Transform testTarget;
    void Start()
    {
        elioAgent = GetComponent<NavMeshAgent>();
        //player.GetComponent<Playercontroller>().enabled = false;
    }

    void Update()
    {
        if (InputManager.YButton())
        {
            hidingAreaNumber++;
            Debug.Log(hidingAreaNumber);
            elioAgent.SetDestination(testTarget.position);
        }
        CheckDistance();
        YouFoundElio();
        //makeElioHidingPlaces();
        time += Time.smoothDeltaTime;
        timeUntilYouCanFindElio += Time.smoothDeltaTime;
    }
    //Gör så att elio kan röra sig runt kartan
    //fixa så elio ska springa ifrån spelaren
    //fixa så elio kan göma sig o bryta "line of site"

    private void YouFoundElio()
    {
        if (time >= 20)
        {
            hidingAreaNumber = Random.Range(1, 5);
            time = 0;
            Debug.Log(hidingAreaNumber);
        }
        if (elioPlayerDistance < 10)
        {
            playerFoundElio = true;
            if (playerFoundElio)
            {
                if (timeUntilYouCanFindElio > 5)
                {
                    timeUntilYouCanFindElio = 0;
                    if (hidingAreaNumber == 1)
                    {
                        elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
                        playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
                        while(playerHidingSpotDistance <= 30)
                        {
                            elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
                            playerHidingSpotDistance = Vector3.Distance(player.transform.position, elioHidingNumber);
                        }
                        Debug.Log(elioHidingNumber);
                        elioAgent.SetDestination(elioHidingNumber);
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
                    }
                }
            }
        }
        else
        {
            playerFoundElio = false;
        }

        if (elioPlayerDistance > 50)
        {

        }
        //if (distance > 60)
        //{
        //    Debug.Log("You are too far away!");
        //    elioAgent.SetDestination(player.transform.position);
        //}
    }

    //    /*
    //     Elio springer och gömmer sig-(klar)
    //     Elio springer till ny posision när du hittar han-(klar)
    //     Elio's områdespositioner är timer kopplade-(klar)
    //     Elio byter område efter en viss tid-(klar)
    //     Elio kommer ha en övergångsfas till sitt nya område?
    //     Elio vet alltid hur långt bort spelaren befinner sig-(klar)
    //     Elio ropar mot spelaren när spelaren går förlångt bort 
    //     Elio ser till att spelaren inte går förlångt bort genom att göra ljud ifrån sig som spelaren hör.
    //     Elio svarar inte på spelarens visselljud när spelaren är inom en viss distans från Elio / göra det svårare för spelaren att hitta Elio
    //     Elio kan inte få ett gömställe nära spelaren när han blir funnen. -
    //    */
    //private void elioFindNewSpot()
    //{
    //    elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
    //}
    private void CheckDistance()
    {
        elioPlayerDistance = Vector3.Distance(elio.transform.position, player.transform.position);
    }
    //private void makeElioHidingPlaces()
    //{
    //    for (int i = 0; i < 4; i++)
    //    {
    //        Area1HidingSpots[i] = new GameObject;
    //    }
    //}
    //IEnumerator ElioEnum()
    //{
    //    elioHidingNumber = Area1HidingSpots[Random.Range(0, Area1HidingSpots.Length)].transform.position;
    //    elioAgent.SetDestination(elioHidingNumber);
    //    yield return new WaitForSeconds(4);
    //}
}

