﻿using UnityEngine;

public class MouseOverStart : MonoBehaviour
{
    public void OnMouseEnter()
    {
        MouseOverSound.select = "Start";
        MouseOverSound.pointerEnter = true;
    }
    public void OnMouseExit()
    {
        MouseOverSound.pointerEnter = false;
        MouseOverSound.pointerFix = false;

    }
}
