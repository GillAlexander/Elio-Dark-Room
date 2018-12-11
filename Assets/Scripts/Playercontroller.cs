using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    float speed = 8;
    float sprint = 2;
    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.y = Input.GetAxis("Vertical") * speed;

        if (movement.x != 0 || movement.y != 0)
            PlayerFootsteps.isMoving = true;
        else
            PlayerFootsteps.isMoving = false;

        //sprint
        if (Input.GetKey("joystick button 4") || Input.GetButton("Sprint"))
        {
            movement.x *= sprint;
            movement.y *= sprint;
            PlayerFootsteps.isRunning = true;
        }
        else
            PlayerFootsteps.isRunning = false;

        movement.x *= Time.deltaTime;
        movement.y *= Time.deltaTime;

        transform.Translate(movement.x, 0, movement.y);

    }

    void OnCollisionStay(Collision hit)
    {
        PlayerFootsteps.surfaceTag = hit.transform.tag;
    }
}
