using System.Collections;
using UnityEngine;

public class PlayerWhistleRaycast : MonoBehaviour
{
    public GameObject EchoSource;
    private RaycastHit contact;
    private GameObject instantiatedEchoSource;
    private float ClapRange = 50;
    private float echoCooldown = 1.5f;
    private float time = 0;

    void Update()
    {
        bool ElioClap = Input.GetButtonDown("Clap");
        time += Time.deltaTime;

        if (ElioClap && time >= echoCooldown)
        {
            if (Physics.Raycast(transform.position, transform.forward, out contact, ClapRange))
            {
                StartCoroutine(EchoDelay(contact));
            }

            if (Physics.Raycast(transform.position, transform.forward - transform.right, out contact, ClapRange))
            {
                StartCoroutine(EchoDelay(contact));
            }

            if (Physics.Raycast(transform.position, transform.forward + transform.right, out contact, ClapRange))
            {
                StartCoroutine(EchoDelay(contact));
            }

            time = 0;
        }
    }


    IEnumerator EchoDelay(RaycastHit hit)
    {
        float delay = hit.distance / 100;
        yield return new WaitForSeconds(delay);
        Debug.Log("distance / 100 = " + delay);

        instantiatedEchoSource = Instantiate(EchoSource, hit.point, transform.rotation);
        Destroy(instantiatedEchoSource, 0.5f);
    }
}
