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

        //if (Input.GetKey("joystick button 4") || Input.GetButton("Sprint"))
        //{
        //    moveVertical *= sprint;
        //    moveHorizontal *= sprint;
        //}
        transform.Translate(moveHorizontal, 0, moveVertical);
    }
}
