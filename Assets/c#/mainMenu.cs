using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour {

    public GameObject UI;
    private bool paused = false;

    

    public void Play()
    {
        Application.LoadLevel(2); // nacita level 1 s indexom 2
    }
    public void Quit()
    {
        Application.Quit();
    }
}
