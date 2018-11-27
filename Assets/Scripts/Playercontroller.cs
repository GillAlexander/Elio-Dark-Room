using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour {

    public float speed;
    Transform position;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        position = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float moveVertical = Input.GetAxis("Vertical") * speed;
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;

        moveVertical *= Time.deltaTime;
        moveHorizontal *= Time.deltaTime;

        transform.Translate(moveHorizontal, 0, moveVertical);

        //float xboxVertical = Input.GetAxisRaw("Vertical") * speed;
        //float xboxHorizontal = Input.GetAxisRaw("Horizontal") * speed;
        //xboxVertical *= Time.deltaTime;
        //xboxHorizontal *= Time.deltaTime;
        //transform.Translate(xboxHorizontal, 0, xboxVertical);
    }
}
