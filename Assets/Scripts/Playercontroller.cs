using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    float speed = 8;
    float sprint = 2;
    Vector2 movement;

    void Update()
    {
        movement.x = InputManager.MainHorizontal() * speed;
        movement.y = InputManager.MainVertical() * speed;

        if (movement.x != 0 || movement.y != 0)
            PlayerFootsteps.isMoving = true;
        else
            PlayerFootsteps.isMoving = false;

        //sprint
        if (InputManager.SprintButton())
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

        CheckGround();
    }

    void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            PlayerFootsteps.surfaceTag = hit.transform.tag;
            Debug.DrawRay(transform.position, hit.point - transform.position, Color.red, 1);
        }
    }
}
