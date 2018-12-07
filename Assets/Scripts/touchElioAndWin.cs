using UnityEngine;

public class touchElioAndWin : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("You found Elio! You won!");

        }

    }
}
