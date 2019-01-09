using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenunewww : MonoBehaviour
{
    public GameObject omMeny;
    public GameObject inställningarMeny;
    public GameObject mainMeny;


    private void Update()
    {
        
    }
    public void PlayGame()
    {
        //MouseOver.select = "Start";

        SceneManager.LoadScene("Elio");
    }

    public void QuitGame()
    {
        //MouseOver.select = "Exit";
        Debug.Log("AVSLUTA!");
        Application.Quit();
    }


    //SceneManager.LoadScene("Elio"); 
    //MouseOver.select = "Start";
    //MouseOver.select = "About";
    //MouseOver.select = "Settings";
    //MouseOver.select = "Exit";

}

