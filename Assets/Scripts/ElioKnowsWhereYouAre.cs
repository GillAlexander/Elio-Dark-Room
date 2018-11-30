using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElioKnowsWhereYouAre : MonoBehaviour
{
    //public Transform Other;
    public GameObject elio;
    public GameObject player;

    public Transform Target;
    //Collider elioRadar;
    void Start()
    {
        //elioRadar = this.GetComponent<SphereCollider>();
    }
    /*
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
    */
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




    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Far")
    //    {
    //        Debug.Log("You are far away");
    //    }
    //    if (collision.gameObject.name == "Middle")
    //    {
    //        Debug.Log("You halfway to Elio");
    //    }
    //    if (collision.gameObject.name == "Close")
    //    {
    //        Debug.Log("You are close to Elio");
    //    }
    //    if ((collision.collider.name == "Far"))
    //    {

    //    }

    //}
}
