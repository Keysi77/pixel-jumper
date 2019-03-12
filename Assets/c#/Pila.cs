using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pila : MonoBehaviour
{

    private Player player;
    public GameObject death;
    public GameObject respawn;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.CompareTag("Player"))
        {
            Instantiate(death, player.transform.position, player.transform.rotation);
            player.Damage(5);
            //StartCoroutine(player.Knockback(0.002f, 550, player.transform.position));       
        }
    }

}
