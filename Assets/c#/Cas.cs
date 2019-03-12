using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cas : MonoBehaviour {
    // odratavanie času
    public int coolDown = 35;
    public float coolDownTimer;
    public Text TimeText; 

    void Update()
    {
        TimeText.text = ("Čas:" + coolDownTimer);
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if(coolDownTimer <0 )
        {
            coolDownTimer = 0;
            SceneManager.LoadScene(1); // ak skonci cas nacita scenu GAME OVER
        }

        if(Input.GetKey("space") && coolDownTimer ==0) // zacne odratavat ak stlacime SPACE           
        {         
            coolDownTimer = coolDown;
        }
    }
}
