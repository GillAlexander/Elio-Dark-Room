using UnityEngine;
using UnityEngine.AI;

public class ElioAI : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;

    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        Debug.Log(distance);
        if (distance <= 25f)
        {
            agent.destination = transform.position - player.position;
        }
        else
        {
            //Wander();
        }
    }


    //void Wander()
    //{
      //  Vector3 wanderDude = new Vector3(Random.Range(-100f, 100f), 0f, Random.Range(-100f, 100f));
     //   agent.destination = wanderDude;

    //}

}

//fixa så att man tar elios position och utgår fårn den när man gör en random wander
//lägg till så att elio beyter riktning efter ett antal sekunder
//flytta wander ut får uppdate.