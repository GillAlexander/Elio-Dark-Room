using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllElioMeshScript : MonoBehaviour
{
    public GameObject elio;
    public GameObject player;
    bool foundElio = false;
    public GameObject[] Area1HidingSpots;
    public GameObject[] Area2HidingSpots;
    public GameObject[] Area3HidingSpots;
    public GameObject[] Area4HidingSpots;
    public NavMeshAgent elioAgent;
    static Vector3 elioHidingNumber;
    int playerHasTouchedElio;
    float hidingAreaNumber = 1;
    float distance;
    public float timeUntilElioMovesToNewArea;
    public float time;

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

        CheckDistance();
        YouFoundElio();
        time += Time.smoothDeltaTime;
    }
    private void YouFoundElio()
    {
            if (time >= 30)
            {
                hidingAreaNumber = Random.Range(1, 5);
                Debug.Log(hidingAreaNumber);
                time = 0;
            }
            if (distance < 8)
            {
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
                else if (hidingAreaNumber == 3)
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
            if (distance > 60)
            {
            Debug.Log("You are too far away!");
            elioAgent.SetDestination(player.transform.position);
        }
    }
    private void OnCollisionEnter(Collision spheres)
    {
        /*
         Elio springer och gömmer sig-
         Elio springer till ny posision när du hittar han-
         Elio's områdespositioner är timer kopplade
         Elio byter område efter en viss tid
         Elio kommer ha en övergångsfas till sitt nya område?
         Elio vet alltid hur långt bort spelaren befinner sig
         Elio ropar mot spelaren när spelaren går förlångt bort 
         Elio ser till att spelaren inte går förlångt bort genom att göra ljud ifrån sig som spelaren hör.
         Elio svarar inte på spelarens visselljud när spelaren är inom en viss distans från Elio / göra det svårare för spelaren att hitta Elio
        */
        if (spheres.gameObject.name == ("Player"))
        {
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
    private void CheckDistance()
    {
        distance = Vector3.Distance(elio.transform.position, player.transform.position);
    }
}

