using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed;
    public float sprint;
    public AudioSource source;
    public AudioClip[] footsteps;

    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical") * speed;
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;

        moveVertical *= Time.deltaTime;
        moveHorizontal *= Time.deltaTime;

        //sprint
        if (Input.GetKey("joystick button 4") || Input.GetButton("Sprint"))
        {
            moveVertical *= sprint;
            moveHorizontal *= sprint;
        }
        transform.Translate(moveHorizontal, 0, moveVertical);

        /*Footsteps
        if (moveVertical != 0 || moveHorizontal != 0)
        {
            source.clip = footsteps[UnityEngine.Random.Range(0, footsteps.Length)];
            source.pitch = UnityEngine.Random.Range(0.85f, 1.2f);

            if (source.isPlaying)
                return;
            else
                source.Play();
        }
        */
    }
}
