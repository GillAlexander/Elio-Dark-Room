using UnityEngine;
using UnityEngine.AI;

public class DeerAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed;
    private float waitTime;
    public float startWaitTime;
    private float rotationSpeed;
    private RaycastHit hit;
    private bool isThereAnyThing = false;
    private int range;

    public Transform[] moveSpot;

    private int randomSpot;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpot.Length);
        agent = GetComponent<NavMeshAgent>();
        rotationSpeed = 5f;
        range = 80;
    }

    void Update()
    {
        //Look At Somthly Towards the Target if there is nothing in front.
        if (!isThereAnyThing)
        {
            Vector3 relativePos = moveSpot[randomSpot].position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }

        //Checking for any Obstacle in front.
        // Two rays left and right to the object to detect the obstacle.
        Transform leftRay = transform;
        Transform rightRay = transform;
        //Use Phyics.RayCast to detect the obstacle
        if (Physics.Raycast(leftRay.position + (transform.right * 7), transform.forward, out hit, range) || Physics.Raycast(rightRay.position - (transform.right * 7), transform.forward, out hit, range))
        {
            if (hit.collider.gameObject.CompareTag("Obstacle"))
            {
                isThereAnyThing = true;
                transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
            }
        }
        // Now Two More RayCast At The End of Object to detect that object has already pass the obsatacle.
        // Just making this boolean variable false it means there is nothing in front of object.
        if (Physics.Raycast(transform.position - (transform.forward * 4), transform.right, out hit, 10) ||
         Physics.Raycast(transform.position - (transform.forward * 4), -transform.right, out hit, 10))
        {
            if (hit.collider.gameObject.CompareTag("Obstacle"))
            {
                isThereAnyThing = false;
            }
        }
        // Use to debug the Physics.RayCast.
        Debug.DrawRay(transform.position + (transform.right * 7), transform.forward * 20, Color.red);
        Debug.DrawRay(transform.position - (transform.right * 7), transform.forward * 20, Color.red);
        Debug.DrawRay(transform.position - (transform.forward * 4), -transform.right * 20, Color.yellow);
        Debug.DrawRay(transform.position - (transform.forward * 4), transform.right * 20, Color.yellow);

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

        Vector3 targetDir = transform.position - moveSpot[randomSpot].position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
        transform.LookAt(moveSpot[randomSpot].position);
    }
}
