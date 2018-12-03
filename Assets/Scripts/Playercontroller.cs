using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed;
    public float sprint;
    public static float moveVertical;
    public static float moveHorizontal;

    void Update()
    {
        moveVertical = Input.GetAxis("Vertical") * speed;
        moveHorizontal = Input.GetAxis("Horizontal") * speed;

        moveVertical *= Time.deltaTime;
        moveHorizontal *= Time.deltaTime;

        //sprint
        if (Input.GetKey("joystick button 4") || Input.GetButton("Sprint"))
        {
            moveVertical *= sprint;
            moveHorizontal *= sprint;
        }

        transform.Translate(moveHorizontal, 0, moveVertical);       
    }    
}
