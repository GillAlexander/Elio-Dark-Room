using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class _TESTPlayerVibrantingWalls : MonoBehaviour {

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    bool playerIndexSet = false;
    public float leftVibration;
    public float rightVibration;
    public float vibrationTime;

    public GameObject redBall;
    void Start () {
		
	}
    /*
     * DWORD dwResult;    
for (DWORD i=0; i< XUSER_MAX_COUNT; i++ )
{
  XINPUT_STATE state;
  ZeroMemory( &state, sizeof(XINPUT_STATE) );

        // Simply get the state of the controller from XInput.
        dwResult = XInputGetState( i, &state );

        if( dwResult == ERROR_SUCCESS )
  {
      // Controller is connected 
  }
        else
  {
            // Controller is not connected 
  }
}
     */
    void Update () {
        if(vibrationTime > 0)
        {
            vibrationTime -= Time.deltaTime;
        }
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }
        prevState = state;
        state = GamePad.GetState(playerIndex);


        
        
    }
    //foreach (ContactPoint contact in wall.contacts)
    //{
    //    GamePad.SetVibration(playerIndex, leftVibration, rightVibration);
    //}
    void OnCollisionEnter(Collision wall)
    {

        if (wall.gameObject.name == ("wall"))
        {
            Debug.Log("You are touching the wall");
            GamePad.SetVibration(playerIndex, leftVibration, rightVibration);

        }
        if (wall.gameObject.name == ("wall"))
        {
            TouchWallVibration();
            //Handheld.vibrate();
        }
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
    }
    void  TouchWallVibration()
    {
        
        if (vibrationTime < 0)
        {
            GamePad.SetVibration(playerIndex, 0, 0);
        }
    }
    void OnCollisionExit(Collision wall)
    {
        Debug.Log("You are not touching the wall");
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
 