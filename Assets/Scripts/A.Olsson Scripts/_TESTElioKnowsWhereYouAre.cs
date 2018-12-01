using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TESTElioKnowsWhereYouAre : MonoBehaviour
{
    //public Transform Other;
    public GameObject elio;
    public GameObject player;

    public Transform Target;

    public float speed;
    //Collider elioRadar;
    void Start()
    {
        //elioRadar = this.GetComponent<SphereCollider>();

    }
    void CheckDistance()
    {
        if (elio)
        {
            float Distance = Vector3.Distance(elio.transform.position, player.transform.position);
            //print("Distance to other: " + Distance);

            if (Distance <= 10)
            {
                Debug.Log("You are less than 10 from me");
                Debug.Log("You found me");
            }
            else if (Distance <= 30)
            {
                Debug.Log("You are Less than 30 from me");
            }
            else
            {
                Debug.Log("You are far away");
            }
        }
    }

    void CheckAngle()
    {
        Vector3 elioPosition = Target.position - transform.position;
        float elioAngle = Vector3.Angle(elioPosition, transform.forward);
        if (elioAngle < 5.0f)
        {
            Debug.Log("You are looking at Elio!");
        }
    }

    //Elio har två functioner
    //true och false
    //Sprint eller gömma sig  

    void Update()
    {
        CheckDistance();
    }

    private void OnTriggerEnter(Collider spheres)
    {
        //Vector3 playerPosition = player.transform.position;
        //Vector3 elioPosition = Target.position - transform.position;
        //float steg = speed * Time.deltaTime;
        if (spheres.gameObject.name == "Far")
        {
            Debug.Log("You are far away");
            //elio.transform.position = Vector3.MoveTowards(playerPosition, playerPosition, steg * Time.deltaTime);
            //elio.transform.position = (elio.transform.position - player.transform.position)/2;
        }
        if (spheres.gameObject.name == "Middle")
        {
            Debug.Log("You halfway to Elio");
        }
        if (spheres.gameObject.name == "Close")
        {
            Debug.Log("You are close to Elio");
        }
    }
    private void OnTriggerExit(Collider spheres)
    {
        if (spheres.gameObject.name == "Far")
        {
            Debug.Log("You are leaving the most far away sphear");
        }
        if (spheres.gameObject.name == ("Middle"))
        {
            Debug.Log("You are leaving the middle sphear");
        }
        if (spheres.gameObject.name == ("Close"))
        {
            Debug.Log("You are leaving the closest sphear");
        }
    }
}
