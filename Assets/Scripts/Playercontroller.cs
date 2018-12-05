using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed;
    public float sprint;
    public float moveVertical;
    public float moveHorizontal;

    void Update()
    {
        moveVertical = Input.GetAxis("Vertical") * speed;
        moveHorizontal = Input.GetAxis("Horizontal") * speed;

        if (moveHorizontal != 0 || moveVertical != 0)
            PlayerFootsteps.isMoving = true;
        else
            PlayerFootsteps.isMoving = false;

        //sprint
        if (Input.GetKey("joystick button 4") || Input.GetButton("Sprint"))
        {
            moveVertical *= sprint;
            moveHorizontal *= sprint;
            PlayerFootsteps.isRunning = true;
        }
        else
            PlayerFootsteps.isRunning = false;

        moveVertical *= Time.deltaTime;
        moveHorizontal *= Time.deltaTime;

        transform.Translate(moveHorizontal, 0, moveVertical);

    }
}
