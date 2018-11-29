using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject selection;

    int currentSelect;
    int newSelect;

    [SerializeField]
    GameObject[] buttons;

	// Use this for initialization
	void Start () {
        currentSelect = 0;
        MoveSelection();
	}
	
	// Update is called once per frame
	void Update () {
        KeyNavigation();
        MouseNavigation();

        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space)) {
            switch (currentSelect) {
                case 0:
                    SceneManager.LoadScene(1);
                    break;
                case 1:
                    SceneManager.LoadScene(2);
                    break;
                case 2:
                    SceneManager.LoadScene(3);
                    break;
                case 3:
                    SceneManager.LoadScene(4);
                    break;
                case 4:
                    Application.Quit();
                    break;
                default:
                    break;
            }
        }
    }

    private void MouseNavigation() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider != null) {
                GameObject target = hit.collider.gameObject;
                switch (target.name) {
                    case "Play":
                        currentSelect = 0;
                        MoveSelection();
                        break;
                    case "Guide":
                        currentSelect = 1;
                        MoveSelection();
                        break;
                    case "Options":
                        currentSelect = 2;
                        MoveSelection();
                        break;
                    case "About":
                        currentSelect = 3;
                        MoveSelection();
                        break;
                    case "Quit":
                        currentSelect = 4;
                        MoveSelection();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void KeyNavigation() {
        if (Input.GetKeyUp("s")) {
            newSelect = currentSelect + 1;
            if (newSelect > (buttons.Length - 1)) {
                newSelect = 0;
            }
            currentSelect = newSelect;
            MoveSelection();
        }
        else if (Input.GetKeyUp("w")) {
            newSelect = currentSelect - 1;
            if (newSelect < 0) {
                newSelect = 4;
            }
            currentSelect = newSelect;
            MoveSelection();
        }
    }

    private void MoveSelection() {
        Vector3 newPos = new Vector3(selection.transform.position.x, selection.transform.position.y, buttons[currentSelect].transform.position.z);
        selection.transform.position = newPos;
    }
}
