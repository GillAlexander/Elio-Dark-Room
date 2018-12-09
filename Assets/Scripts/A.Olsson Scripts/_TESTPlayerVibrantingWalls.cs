using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.Audio;


// IFplayer is touching wall
//If player is walking
//Två bools 
//Båda måste vara true för att få vibration respons. 
//Koppla isplayer moving till vibration scriptet. 
//ifall spelaren springer blir det snabbare vibrationer. 
//
public class _TESTPlayerVibrantingWalls : MonoBehaviour
{

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    bool playerIndexSet = false;
    public float vibrationTime;
    public float vibrationDuration;
    [Range(0, 65)]
    public float leftVibration;
    [Range(0, 65)]
    public float rightVibration;
    bool playerIsTouchingWall = false;
    bool playerIsWalkingWhileTouchingwall = false;

    //Johans ljud
    public AudioSource source;
    public AudioClip[] walkGrass;
    public AudioMixerGroup audioMixer;
    public static bool isMoving = false;
    public static bool isRunning = false;
    public static int startedRunning;


    void Start()
    {
        StartCoroutine(Footsteps());
    }
    void Update()
    {
        if (vibrationTime > 0)
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
            playerIsTouchingWall = true;
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
        if (collision.gameObject.name == ("tree"))
        {
            Debug.Log("You are touching the tree");
            if (vibrationTime < 0)
            {
                GamePad.SetVibration(playerIndex, 0, 0);
            }
            else
            {
                GamePad.SetVibration(playerIndex, 0, 0.25f);
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
        playerIsTouchingWall = false;
        Debug.Log("You are not touching the wall");
        GamePad.SetVibration(playerIndex, 0, 0);
    }

    public IEnumerator Footsteps()
    {
        if (isMoving){
            playerIsWalkingWhileTouchingwall = true;
            if (playerIsWalkingWhileTouchingwall)
            {
                Debug.Log("playeriswlakingwhiletouchingwall");
            }
            if (isRunning){
                source.clip = walkGrass[Random.Range(0, walkGrass.Length)];
            }
            else{
                source.clip = walkGrass[Random.Range(0, walkGrass.Length)];
                GamePad.SetVibration(playerIndex, 0, 0);
            }
            if (playerIsTouchingWall)
            {
                if (playerIsWalkingWhileTouchingwall)
                {
                    Debug.Log("You are touching the wall and moving");
                }
            }
            source.pitch = Random.Range(0.85f, 1.15f);
            source.outputAudioMixerGroup = audioMixer;
            source.Play();
        }
        if (!isMoving)
        {
            playerIsWalkingWhileTouchingwall = false;
        }
        if (isRunning){
            yield return new WaitForSeconds(0.3f);
            GamePad.SetVibration(playerIndex, 0.5f, 0.5f);
        }
        else
            yield return new WaitForSeconds(0.5f);
        GamePad.SetVibration(playerIndex, 0, 0);
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
