using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level3script : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        // ak je trigernuty objekt s tagom Player
        if (col.tag == "Player")
        {
            // prepnutie do druhej sceny podla id=2
            // Application.LoadLevel(2);
            SceneManager.LoadScene(4); // nacita level 2 s id=3
        }
    }
}
