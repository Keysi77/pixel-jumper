using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mina : MonoBehaviour {

    private Player player;
    public GameObject death;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Instantiate(death, player.transform.position, player.transform.rotation);
            player.Damage2(4); // damage ktore sposobi
            StartCoroutine(player.Knockback(0.01f, 50, player.transform.position));

        }
    }
}
