using UnityEngine;

public class ElioSounds : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            int rnd = Random.Range(0, 2);
            
        }
    }
}
