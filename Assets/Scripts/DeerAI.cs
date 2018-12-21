using UnityEngine;
using UnityEngine.AI;

public class DeerAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpot;

    private int randomSpot;

    // Use this for initialization
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpot.Length);
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot[randomSpot].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveSpot[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0f)
            {
                randomSpot = Random.Range(0, moveSpot.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) 
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Hit");
        }
    }
}
