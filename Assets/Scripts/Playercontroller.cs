using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed;
    public float sprint;
    public AudioSource elio;
    private void Start()
    {
        elio.GetComponent<AudioSource>();
    }
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical") * speed;
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;

        moveVertical *= Time.deltaTime;
        moveHorizontal *= Time.deltaTime;

        if (Input.GetKey("joystick button 4") || Input.GetButton("Sprint"))
        {
            moveVertical *= sprint;
            moveHorizontal *= sprint;
        }
        transform.Translate(moveHorizontal, 0, moveVertical);        
    }
}
