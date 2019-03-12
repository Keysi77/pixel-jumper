using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohybPlatformyHore : MonoBehaviour {

    public float range;
    public float speed;

    private Vector2 start, pos;
    private bool player;
    private GameObject playOBJ;


    // Use this for initialization
    void Start()
    {
        start = transform.position;
        player = false;
    }


    private void Slide()
    {
        Vector2 move;
        move.y = speed;
        move.x = 0.0f;
        transform.Translate(move);
        if (player)
        {
            playOBJ.transform.Translate(move);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = true;
            playOBJ = col.gameObject;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        pos = transform.position;
        if ((pos.y - start.y) > range)
        {
            speed *= -1.0f;
            Slide();
        }
        else if (pos.y < start.y)
        {
            speed *= -1.0f;
            Slide();
        }
        else
        {
            Slide();
        }
    }


}
