using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Healthpack : MonoBehaviour {
    // pre pridavanie zdravia, ked zoberieme lekarničku zo zeme
    public int Health2give;

    public void OnTriggerEnter2D(Collider2D col)
    {
        var player = col.GetComponent<Player>();

        if (player == null)
            return;
        player.GiveHealth(Health2give);   
        gameObject.SetActive(false);      
    }		
	
}
