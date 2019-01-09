using UnityEngine;

public class MouseOverAbout : MonoBehaviour
{
    public void OnMouseEnter()
    {
        MouseOverSound.select = "About";
        MouseOverSound.pointerEnter = true;
    }
    public void OnMouseExit()
    {
        MouseOverSound.pointerEnter = false;
        MouseOverSound.pointerFix = false;

    }
}