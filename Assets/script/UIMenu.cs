using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour {

    public GameObject tutorial;
    

	void Start () {
        tutorialOff();
        cursorOn();
	}

    public void tutorialOff()
    {
        tutorial.SetActive(false);
    }

    public void tutorialOn()
    {
        tutorial.SetActive(true);
    }
    public void cursorOn()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; ;
    }
}
