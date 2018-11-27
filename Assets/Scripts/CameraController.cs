using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class CameraController : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 xboxLook;

    public float sensitivity;

    GameObject character; 

	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;

	}
	
	// Update is called once per frame
	void Update () {
        //Vector2 cameraChange = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 xboxCamera = new Vector2(Input.GetAxis("xboxX"), Input.GetAxisRaw("xboxY"));

        //cameraChange = Vector2.Scale(cameraChange, new Vector2(sensitivity, sensitivity));
        xboxCamera = Vector2.Scale(xboxCamera, new Vector2(sensitivity, sensitivity));

        //mouseLook += cameraChange;
        //mouseLook.y = Mathf.Clamp(mouseLook.y, -90, 90);

        xboxLook += xboxCamera;
        xboxLook.y = Mathf.Clamp(xboxCamera.y, -90, 90);

        //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        //character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        transform.localRotation = Quaternion.AngleAxis(-xboxLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(xboxLook.x, character.transform.up);


        //character.transform.localRotation *= Quaternion.Euler(0.0f, state.ThumbSticks.Right.X * 25.0f * Time.deltaTime, 0.0f);
        //transform.localRotation *= Quaternion.Euler(0.0f, state.ThumbSticks.Right.Y * 25.0f * Time.deltaTime, 0.0f);
       
    }
}
