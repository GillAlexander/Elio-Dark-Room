using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour
{
    bool ingetValt = true;
    bool starta = false;
    bool om = false;
    bool installningar = false;
    bool avsluta = false;

    private void Start()
    {
        Debug.Log("Scen laddad, inget är valt");
    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            StartaVal();
        }
        //else if (/*knapp nedåt*/)
        //{

        //}
        //else if (/*knapp vänster*/)
        //{

        //}
        //else if (/*knapp höger*/)
        //{

        //}

    }

    void StartaVal ()
    {
        if (Input.GetKeyDown("w") && starta == true)
        {
            Debug.Log("Bekräftat, laddar en cool scen här!");
            //SceneLoader("PHilips scene");

            //De här tre raderna är mest för test
            starta = false;
            ingetValt = true;
            return;
        }

        starta = true;
        ingetValt = false;
        Debug.Log("Klickat på uppåt, klicka upp igen för att bekräfta");

        //Gör grejen här som spelar upp ljud eller något.
        //"tryck upp igen för att starta!"

    }

    void OmVal ()
    {

    }

    void InstallningarVal ()
    {

    }

    void AvslutaVal ()
    {

    }

    void SceneLoader (string scene)
    {
        //Kalla någon av dessa när du har klickat på en knapp
        //Start          "PHilips scene"
        //Om             "String"
        //Installningar  "String"
        //Avsluta        "String"

        SceneManager.LoadScene(scene);
    }

}
