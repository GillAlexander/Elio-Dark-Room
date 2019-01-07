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
public class Vibrations : MonoBehaviour
{

    //PlayerIndex 0;
    GamePadState state;
    GamePadState prevState;
    //bool playerIndexSet = false;
    public float vibrationTime;
    public float vibrationDuration;
    [Range(0, 65)]
    public float leftVibration;
    [Range(0, 65)]
    public float rightVibration;
    //bool playerIsTouchingWall = false;
    //bool playerIsWalkingWhileTouchingwall = false;

    //Johans GÅ kod, kan användas vid kollision/glid till väggarna
    //public static bool isMoving = false;
    //public static bool isRunning = false;
    //public static int startedRunning;

    void Update()
    {
        if (vibrationTime > 0)
        {
            vibrationTime -= Time.deltaTime;
        }

    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "InvisWall")
        {
            if (vibrationTime < 0)
            {
                GamePad.SetVibration(0, 0, 0);
            }
            else if(vibrationTime >= 0.3)
            {
                GamePad.SetVibration(0, leftVibration, rightVibration);
            }
        }

        /*
        if (collision.gameObject.layer == 16)
        {
            Debug.Log("You are touching the tree");
            if (vibrationTime < 0)
            {
                GamePad.SetVibration(0, 0, 0);
            }
            else
            {
                GamePad.SetVibration(0, 0, 0.25f);
            }
        }
        */
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("wall"))
        {
            vibrationTime = vibrationDuration;
        }
        //if (TerrainData.FindObjectOfType<Tree>().tag == "Tree")
        //{
        //    vibrationTime = vibrationDuration;
        //}
        if (collision.gameObject.tag == "InvisWall")
        {
            vibrationTime = vibrationDuration;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        //playerIsTouchingWall = false;
        //Debug.Log("You are not touching the wall");
        GamePad.SetVibration(0, 0, 0);
    }

    //public IEnumerator Footsteps()
    //{
    //    if (PlayerFootsteps.isMoving && playerIsTouchingWall)
    //    {
    //        Debug.Log("ifIsMoving = You are moving and touching the wall");
    //        GamePad.SetVibration(playerIndex, 1f, 0);

    //    }
    //    if (PlayerFootsteps.isMoving && !playerIsTouchingWall)
    //    {
    //        Debug.Log("ifIsMoving = You are moving and but not touching the wall");
    //        GamePad.SetVibration(playerIndex, 0, 0);
    //    }
    //    if (!PlayerFootsteps.isMoving && !playerIsTouchingWall)
    //    {
    //        Debug.Log("ifIsMoving = You are not moving and not touching the wall");
    //        GamePad.SetVibration(playerIndex, 0, 0);
    //    }
    //    if (!PlayerFootsteps.isMoving && playerIsTouchingWall)
    //    {
    //        Debug.Log("ifIsMoving = You are not moving and touching the wall");
    //        GamePad.SetVibration(playerIndex, 0, 0);
    //    }
    //    //else
    //    //{
    //    //    Debug.Log("Else!IsMoving = You are not moving");
    //    //}
    //    //if (isMoving){
    //    //    Debug.Log("You are moving");

    //    //    if (playerIsWalkingWhileTouchingwall)
    //    //    {
    //    //        Debug.Log("playeriswlakingwhiletouchingwall");
    //    //    }
    //    //    if (isRunning){
    //    //        source.clip = walkGrass[Random.Range(0, walkGrass.Length)];
    //    //    }
    //    //    else{
    //    //        source.clip = walkGrass[Random.Range(0, walkGrass.Length)];
    //    //        //GamePad.SetVibration(playerIndex, 0, 0);
    //    //    }
    //    //    if (playerIsTouchingWall)
    //    //    {
    //    //        Debug.Log("You are debuging and touching the wall");
    //    //        if (playerIsWalkingWhileTouchingwall)
    //    //        {
    //    //            Debug.Log("You are touching the wall and moving");
    //    //        }
    //    //    }
    //    //    source.pitch = Random.Range(0.85f, 1.15f);
    //    //    source.outputAudioMixerGroup = audioMixer;
    //    //    source.Play();
    //    //}
    //    //else
    //    //{
    //    //    Debug.Log("You are not moving");
    //    //    playerIsWalkingWhileTouchingwall = false;
    //    //}

    //    if (isRunning)
    //    {
    //        yield return new WaitForSeconds(0.3f);
    //        GamePad.SetVibration(playerIndex, 0.5f, 0.5f);
    //    }
    //    else
    //    {
    //        yield return new WaitForSeconds(0.5f);
    //    }

    //    GamePad.SetVibration(playerIndex, 0, 0);
    //    StartCoroutine(Footsteps());
    //}
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
