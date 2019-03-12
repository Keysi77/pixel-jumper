using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level2Script : MonoBehaviour {
	// pre ukončenie levelu a načitanie dalšej sceny

	void OnTriggerEnter2D(Collider2D col){
		// ak je trigernuty objekt s tagom Player
		if (col.tag == "Player") {
           // prepnutie do druhej sceny podla id=2
           // Application.LoadLevel(2);
            SceneManager.LoadScene(3); // nacita level 2 s id=3
        }		
	}
	
}




