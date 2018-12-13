using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    
    //Axis
    public static float MainHorizontal()
    {
        float result = 0.0f;
        result += Input.GetAxis("J_MainHorizontal");
        result += Input.GetAxis("K_MainHorizontal");

        return Mathf.Clamp(result, -1.0f, 1.0f);
    }
    public static float MainVertical()
    {
        float result = 0.0f;
        result += Input.GetAxis("J_MainVertical");
        result += Input.GetAxis("K_MainVertical");

        return Mathf.Clamp(result, -1.0f, 1.0f);
    }
    public static Vector3 MainJoystick()
    {
        return new Vector3(MainHorizontal(), 0, MainVertical());
    }

    //Camera Axis
    public static float MainCameraHorizontal()
    {
        float result = 0.0f;
        result += Input.GetAxis("Mouse X");
        result += Input.GetAxis("xboxX");

        return Mathf.Clamp(result, -1.0f, 1.0f);
    }
    public static float MainCameraVertical()
    {
        float result = 0.0f;
        result += Input.GetAxis("Mouse Y");
        result += Input.GetAxis("xboxY");

        return Mathf.Clamp(result, -1.0f, 1.0f);
    }
    public static Vector3 MainCameraController()
    {
        return new Vector3(MainCameraHorizontal(), 0, MainCameraVertical());
    }

    //Knappar
    public static bool ClapButton()
    {
        return Input.GetButton("Clap");
    }
    public static bool Whistle()
    {
        return Input.GetButton("Whistle");
    }
    public static bool XButton()
    {
        return Input.GetButton("X_Button");
    }
    public static bool YButton()
    {
        return Input.GetButton("Y_Button");
    }
    public static bool SprintButton()
    {
        return Input.GetButton("Sprint");
    }
    public static bool WhistleButton()
    {
        return Input.GetButton("Whistle");
    }
    //Note To self, GetButtonDown = 1frame. GetButton = While hodling down
}
