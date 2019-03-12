using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // pre scene managment

public class GameOver : MonoBehaviour {
	// game over scena	
	void OnGUI(){
		
		//ak klikneme na opakovať spusti sa scena 0 (level 1)
		GUI.contentColor = Color.grey;
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 +150,100,40),"Opakovať")){
            //Application.LoadLevel(0);
            SceneManager.LoadScene(0);
        }
		//skonci aplikaciu
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 +200,100,40),"Skončiť hru")){
			Application.Quit();
            
		}
	}
	
}