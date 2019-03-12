using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voda : MonoBehaviour {

    //   public LevelManager levelManager;
    private Player player;


    void Start()
    {
        //  levelManager = FindObjectOfType<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(5);         
        }


    }
}
