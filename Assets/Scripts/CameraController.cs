using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class CameraController : MonoBehaviour
{
    GameObject character;
    Vector2 mouseLook;
    public float sensitivity;

    void Start()
    {
        character = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Vector2 cameraChange = new Vector2(InputManager.MainCameraHorizontal(), InputManager.MainCameraVertical());
        Vector2 cameraChange = new Vector2(InputManager.MainCameraHorizontal(), 0);
        cameraChange = Vector2.Scale(cameraChange, new Vector2(sensitivity, sensitivity));
        mouseLook += cameraChange;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90, 90);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
