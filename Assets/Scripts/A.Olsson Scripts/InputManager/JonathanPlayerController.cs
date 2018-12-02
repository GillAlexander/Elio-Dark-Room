using UnityEngine;

public class JonathanPlayerController : MonoBehaviour
{
    public float speed;
    public float sprint;

    void Update()
    {
        //float moveVertical = Input.GetAxis("Vertical") * speed;
        //float moveHorizontal = Input.GetAxis("Horizontal") * speed;

        //moveVertical *= Time.deltaTime;
        //moveHorizontal *= Time.deltaTime;

        //transform.Translate(moveHorizontal, 0, moveVertical);

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
        }
        if (InputManager.YButton())
        {
            Debug.Log("you are pressing Y Button");
        }

        //if (Input.GetKey("joystick button 4") || Input.GetButton("Sprint"))
        //{
        //    moveVertical *= sprint;
        //    moveHorizontal *= sprint;
        //}
        transform.Translate(moveHorizontal, 0, moveVertical);
    }
}
