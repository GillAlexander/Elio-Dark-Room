using UnityEngine;
using XInputDotNetPure;

public class JonathanPlayerController : MonoBehaviour
{
    public float speed;
    public float sprint;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    public int leftVibration;
    public int rightVibration;
    bool playerIndexSet = false;

    void FixedUpdate()
    {
        //GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
    }
    void Update()
    {
        float moveVertical = InputManager.MainVertical() * speed;
        float moveHorizontal = InputManager.MainHorizontal() * speed;

        if (moveHorizontal != 0 || moveVertical != 0)
            PlayerFootsteps.isMoving = true;
        else
            PlayerFootsteps.isMoving = false;

        moveVertical *= Time.deltaTime;
        moveHorizontal *= Time.deltaTime;

        if (InputManager.SprintButton())
        {
            moveVertical *= sprint;
            moveHorizontal *= sprint;

            Debug.Log("You are now sprinting");
            PlayerFootsteps.isRunning = true;
        }
        else
            PlayerFootsteps.isRunning = false;
        
        if (InputManager.AButton())
        {
            Debug.Log("you are pressing A Button");
        }
        if (InputManager.BButton())
        {
            Debug.Log("you are pressing B Button");
        }
        if (InputManager.XButton())
        {
            Debug.Log("you are pressing X Button");
        }
        if (InputManager.YButton())
        {
            Debug.Log("you are pressing Y Button");
        }
        if (InputManager.WhistleButton())
        {
            Debug.Log("You pressed the spacebar");
        }

        transform.Translate(moveHorizontal, 0, moveVertical);


    }
}