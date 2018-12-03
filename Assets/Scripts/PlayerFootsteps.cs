using System.Collections;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] footsteps;
    bool isMoving;

    void Start()
    {
        StartCoroutine(Footsteps());
    }

    IEnumerator Footsteps()
    {
        if (Playercontroller.moveHorizontal != 0 || Playercontroller.moveVertical != 0)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving)
        {
            source.clip = footsteps[Random.Range(0, footsteps.Length)];
            source.pitch = Random.Range(0.85f, 1.2f);
            source.Play();
        }

        yield return new WaitForSeconds(1);
        StartCoroutine(Footsteps());
    }
}
