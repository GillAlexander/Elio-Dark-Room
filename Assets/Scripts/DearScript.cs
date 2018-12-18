using UnityEngine;
using UnityEngine.AI;

public class DearScript : MonoBehaviour
{

    public NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
