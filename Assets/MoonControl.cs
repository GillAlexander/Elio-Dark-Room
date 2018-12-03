using UnityEngine;

public class MoonControl : MonoBehaviour
{
    public float scale = 15.0f;
    // Use this for initialization
    void Start()
    {
        transform.localScale = new Vector3 (scale, scale, scale);
    }
}
