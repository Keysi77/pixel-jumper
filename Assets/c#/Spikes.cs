using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour
{
 //   public LevelManager levelManager;
    private Player player;
    public GameObject death;
    public GameObject respawn;

    void Start()
    {
      //  levelManager = FindObjectOfType<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {

      //  if (col.name == "Player")
      //  {
       //     levelManager.RespawnPlayer();
      //  }

        if (col.CompareTag("Player"))
        {
            Instantiate(death, player.transform.position, player.transform.rotation);
            
            player.Damage(3);
            // odhodenie hrača ak je zasiahnuty nepriatelom
            StartCoroutine(player.Knockback(0.02f, 450, player.transform.position));
          //  levelManager.RespawnPlayer();
        }
        

    }

}