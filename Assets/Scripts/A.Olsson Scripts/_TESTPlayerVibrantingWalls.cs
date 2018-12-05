using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.Audio;

public class _TESTPlayerVibrantingWalls : MonoBehaviour {

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    bool playerIndexSet = false;
    public float leftVibration;
    public float rightVibration;
    public float vibrationTime;
    public float vibrationDuration;

    //Johans ljud
    public AudioSource source;
    public AudioClip[] walkGrass;
    public AudioMixerGroup audioMixer;
    public static bool isMoving = false;
    public static bool isRunning = false;
    public static int startedRunning;


    void Start () {
        StartCoroutine(Footsteps());
    }
    void Update () {
        if(vibrationTime > 0)
        {
            vibrationTime -= Time.deltaTime;
        }

        if (isRunning)
            startedRunning++;
        else
            startedRunning = 0;

        if (startedRunning == 1)
        {
            StopAllCoroutines();
            StartCoroutine(Footsteps());
        }

    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == ("wall"))
        {
            Debug.Log("You are touching the wall");
            if (vibrationTime < 0)
            {
                GamePad.SetVibration(playerIndex, 0, 0);
            }
            else
            {
                GamePad.SetVibration(playerIndex, leftVibration, rightVibration);
            }
        }
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal * 10, Color.white);            
        }

        if (collision.gameObject.name == ("outerWall"))
        {
            GamePad.SetVibration(playerIndex, 1, 1);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("wall"))
        {
            vibrationTime = vibrationDuration;
        }
        if (collision.gameObject.name == ("tree"))
        {
            vibrationTime = vibrationDuration;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("You are not touching the wall");
        GamePad.SetVibration(playerIndex, 0, 0);
    }

    public IEnumerator Footsteps()
    {
        if (isMoving)
        {

            if (isRunning)
            {
                //source.clip = runGrass[Random.Range(0, walkGrass.Length)];
                source.clip = walkGrass[Random.Range(0, walkGrass.Length)];

            }

            else
                source.clip = walkGrass[Random.Range(0, walkGrass.Length)];


            source.pitch = Random.Range(0.85f, 1.15f);
            source.outputAudioMixerGroup = audioMixer;
            source.Play();
        }

        if (isRunning)
            yield return new WaitForSeconds(0.3f);
        else
            yield return new WaitForSeconds(0.5f);

        StartCoroutine(Footsteps());
    }
}





//Handheld.vibrate();
/*
          function Update()
          {
              timeLeft -= Time.deltaTime;
              if ( timeLeft < 0 )
              {
                  GameOver();
              }
          }
      */
