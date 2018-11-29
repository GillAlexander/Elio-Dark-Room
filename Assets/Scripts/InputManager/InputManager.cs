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

    //Knappar
    public static bool AButton()
    {
        return Input.GetButtonDown("A_Button");
    }
    public static bool BButton()
    {
        return Input.GetButtonDown("A_Button");
    }
    public static bool XButton()
    {
        return Input.GetButtonDown("A_Button");
    }
    public static bool YButton()
    {
        return Input.GetButtonDown("A_Button");
    }
    public static bool SprintButton()
    {
        return Input.GetButtonDown("Sprint_Button");
    }

}
