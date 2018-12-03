using UnityEngine;

public class touchElioAndWin : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Debug.Log("You found Elio! You won!");

    }
}
