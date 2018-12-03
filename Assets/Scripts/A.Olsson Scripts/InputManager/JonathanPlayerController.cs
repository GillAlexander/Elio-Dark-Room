using UnityEngine;
using XInputDotNetPure;

public class JonathanPlayerController : MonoBehaviour
{
    public float speed;
    public float sprint;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    bool playerIndexSet = false;
    void FixedUpdate()
    {
        GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
    }
    void Update()
    {
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }
        prevState = state;
        state = GamePad.GetState(playerIndex);

        float moveVertical = InputManager.MainVertical() * speed;
        float moveHorizontal = InputManager.MainHorizontal() * speed;

        moveVertical *= Time.deltaTime;
        moveHorizontal *= Time.deltaTime;

        if (InputManager.SprintButton())
        {
            moveVertical *= sprint;
            moveHorizontal *= sprint;

            Debug.Log("You are now sprinting");
        }
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
            GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
        }
        if (InputManager.YButton())
        {
            Debug.Log("you are pressing Y Button");
        }

        transform.Translate(moveHorizontal, 0, moveVertical);


    }
}