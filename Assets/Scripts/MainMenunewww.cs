using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenunewww : MonoBehaviour
{

    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Elio");
    }

    public void QuitGame()
    {
        Debug.Log("AVSLUTA!");
        Application.Quit();
    }

}

