using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {

    public Text defaultScore;
    public string newScore;


	void Start () {
		
	}
	
	
	void Update () {
        defaultScore.text = newScore;
	}
}
