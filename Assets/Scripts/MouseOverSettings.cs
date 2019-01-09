using UnityEngine;

public class MouseOverSettings : MonoBehaviour
{
    public void OnMouseEnter()
    {
        MouseOverSound.select = "Settings";
        MouseOverSound.pointerEnter = true;
    }
    public void OnMouseExit()
    {
        MouseOverSound.pointerEnter = false;
        MouseOverSound.pointerFix = false;

    }
}