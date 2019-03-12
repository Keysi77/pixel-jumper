using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    // Integers
    public int curHealth;
    public int maxHealth;

    // Floats
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    // Booleans
    public bool awake = false;
    public bool lookingRight = true;

    // Referencie
    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft;
    public Transform shootPointRight;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        curHealth = maxHealth;
    }
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookingRight", lookingRight);
    }
    void RangeCheck()
    {
        // podmienky pri zistovani vzdialenosti hraca od nepriatela
        distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance < wakeRange)
        {
            awake = true;
        }
        if(distance > wakeRange)
        {
            awake = false;
        }
    }

}
