using UnityEngine;

public class ElioSounds : MonoBehaviour
{
    
    void Start()
    {

    }
    
    void Update()
    {
        if (Input.GetButtonDown("Jump") && elio)
        {
            elio.Play(0);
        }
    }
}
