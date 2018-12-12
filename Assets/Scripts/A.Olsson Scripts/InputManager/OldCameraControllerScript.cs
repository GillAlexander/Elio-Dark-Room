using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class OldCameraControllerScript : MonoBehaviour
{
    GameObject character;
    Vector2 mouseLook;
    Vector2 xboxLook;
    public float sensitivity;

    void Start()
    {
        character = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }
    //BlitzBurn was here
    void Update()
    {
        Vector2 cameraChange = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        cameraChange = Vector2.Scale(cameraChange, new Vector2(sensitivity, sensitivity));
        mouseLook += cameraChange;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90, 90);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);


        Vector2 xboxCamera = new Vector2(Input.GetAxis("xboxX"), Input.GetAxisRaw("xboxY"));
        xboxCamera = Vector2.Scale(xboxCamera, new Vector2(sensitivity, sensitivity));
        xboxLook += xboxCamera;
        xboxLook.y = Mathf.Clamp(xboxCamera.y, -90, 90);
        if (xboxCamera.x != 0 || xboxCamera.y != 0)
        {
            transform.localRotation = Quaternion.AngleAxis(-xboxLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(xboxLook.x, character.transform.up);
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
