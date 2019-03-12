using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes2 : MonoBehaviour {


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
            player.Damage(3);
            Instantiate(death, player.transform.position, player.transform.rotation);
            // odhodenie hrača ak je zasiahnuty nepriatelom
            StartCoroutine(player.Knockback(0.02f, 150, player.transform.position));
        }

    }
}
