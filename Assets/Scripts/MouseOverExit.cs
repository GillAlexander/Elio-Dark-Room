using UnityEngine;

public class MouseOverExit : MonoBehaviour
{
    public void OnMouseEnter()
    {
        MouseOverSound.select = "Exit";
        MouseOverSound.pointerEnter = true;
    }
    public void OnMouseExit()
    {
        MouseOverSound.pointerEnter = false;
        MouseOverSound.pointerFix = false;

    }
}
