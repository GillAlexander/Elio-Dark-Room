using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseHooverScript : MonoBehaviour
{

    public void OnMouseEnter()
    {
        MouseOver.select = "Start";

    }
    public void OnMouseExit()
    {
        MouseOver.pointerEnter = false;
        MouseOver.pointerFix = false;

    }
}
