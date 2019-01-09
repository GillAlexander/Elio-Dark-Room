using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseHooverScript : MonoBehaviour
{

    public void OnMouseEnter()
    {
        MouseOver.select = "Start";
        MouseOver.pointerEnter = true;
    }
    public void OnMouseExit()
    {
        MouseOver.pointerEnter = false;
        MouseOver.pointerFix = false;

    }
}
