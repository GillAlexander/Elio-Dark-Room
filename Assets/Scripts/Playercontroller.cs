﻿using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed = 5;
    float sprint = 2;
    Vector2 movement;
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            speed += 0.5f;
        }
        if (Input.GetKeyDown("o"))
        {
            speed -= 0.5f;
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit(); // Quits the game
        }
        movement = new Vector2(InputManager.MainHorizontal() * speed, InputManager.MainVertical() * speed);

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

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
            PlayerFootsteps.surfaceTag = hit.transform.tag;
    }
}
