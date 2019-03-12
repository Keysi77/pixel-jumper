using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadajucaPlatforma : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float fallDelay;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player")) // ak narazi na hraca zacne sa prepadat
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb2d.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true; // aby sa prepadol cez vsetko aj collider 
        yield return  0;
    }
   
}
