using System.Collections;
using UnityEngine;

public class PlayerWhistleRaycast : MonoBehaviour
{
    public GameObject EchoSource;
    private RaycastHit contact;
    private GameObject instantiatedEchoSource;
    private float ClapRange = 100;
    private float echoCooldown = 1;
    private float time = 0;

    void Update()
    {
        bool ElioClap = Input.GetButtonDown("Clap");
        time += Time.deltaTime;

        if (ElioClap && time >= echoCooldown)
        {
            for (float i = 0.8f; i > -0.8; i -= 0.1f)
            {
                if (Physics.Raycast(transform.position, transform.forward - (i * transform.right), out contact, ClapRange))
                    StartCoroutine(EchoDelay(contact));
            }
            time = 0;
        }
    }


    IEnumerator EchoDelay(RaycastHit hit)
    {
        float delay;

        delay = (hit.distance * 0.0029154519f) * 5;

        yield return new WaitForSeconds(delay);

        instantiatedEchoSource = Instantiate(EchoSource, hit.point, transform.rotation);
        Destroy(instantiatedEchoSource, 0.5f);
    }
}
