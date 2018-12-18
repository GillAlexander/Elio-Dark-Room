using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {

    public Text Score;
    //public string newScore;
    private int count;

	void Start () {
        count = 0;
        Score.text = "Score: " + count.ToString();
    }
	
	
	void Update () {
        count = count + 1;
        Score.text = "Score: " + count.ToString();

    }
}
