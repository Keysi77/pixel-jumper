using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private Player player;

    public GameObject death;
    public GameObject respawn;


	void Start () {
        player = FindObjectOfType<Player>();
	}
	

	void Update () {
		
	}
    public void RespawnPlayer()
    {
       // Instantiate(death, player.transform.position, player)
        //Debug.Log("Player respawn");
        player.transform.position = currentCheckpoint.transform.position; 
    }
}
