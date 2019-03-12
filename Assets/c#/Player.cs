using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    // Premenne

    
    
    // floaty
    public float maxSpeed = 3; // aby nezrychloval donekočna
    public float speed = 50f;
    public float jumpPower;
    public float groundRadius = 1.2f;
    
    //booleans
    public bool canDoubleJump;
    public bool grounded = false; // kontroluje, či je hrač na zemi alebo nieje
    private bool player; // pre platformu

    // referencie
    private Vector2 start, pos;
    private GameObject playOBJ;
    private PohybPlatformy pohybPlatformy;
    public Text Lives;
    public Transform GroundCheck;
    private Rigidbody2D rb2d;
    private Animator anim; // pre animacie
    private gameMaster gm;
    public AudioSource zvukMinca;
    public AudioSource zvukMinca2;
    public AudioSource zvukHit;
    public LayerMask whatIsGround;
    public LevelManager levelManager;
    public GameObject currentCheckpoint;
    public GameObject respawn;

    // Integery
    public int curLives;
    public int oneLive = 1;
    public int maxLives;
    public int curHealth = 5; // musi byt 5 aby nebolo out of range
    public int maxHealth ;

    void Start ()
    {
       // pohybPlatformy = FindObjectOfType<PohybPlatformy>();
        // pohybPlatformy = GameObject.FindGameObjectWithTag("PohybPlatformy").GetComponent<PohybPlatformy>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        curHealth = maxHealth; // zdravie
        start = transform.position;
        player = false;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();    
	}
		
	void Update ()
    {
        //s Lives.text = ("Zivoty:" + curLives);
        // POHYB doprava / dolava
        
        anim.SetBool("Grounded",grounded); // Bool grounded
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x)); // Float speed
        // aby sa invertovala animacia, ked sa hyba A a D 
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1); 
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
   
        
        // SKAKANIE
        bool jump = Input.GetButtonDown("Jump");
        grounded = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, whatIsGround);

        if (jump && grounded)
        { 
            if(grounded)
            {
            rb2d.AddForce(Vector3.up * jumpPower);
            canDoubleJump = true;
            }
            else
             {
                if (canDoubleJump) // double Jump (nefunguje)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower / 1.75f); // druhy skok aby bol menši
                }
            }
        }
       
        // porovnanie zdravia, aby sme zistli či sme mrtvy
        if (curHealth > maxHealth)
        {
             curHealth = maxHealth;
        }
       
        if(curHealth <= 0 )
        {
            
            //levelManager.RespawnPlayer();
           
             Die(); // level od zaciatku
           // Die2(); // gameover
        }

       /*   if(curHealth <= 0 && curLives ==3)
        {          
           
              Die2(); // ak nemame zdravie vyvolame funkciu Die, ktora restartne hru
            curLives = 2;
        }
          else if (curHealth <= 0 && curLives == 2)
        {
           
            Die2(); // ak nemame zdravie vyvolame funkciu Die, ktora restartne hru
            curLives = 1;
        }
        else if (curHealth <= 0 && curLives == 1)
        {
            Die();
        }
        */
      //  if (curLives <=0)
        //{
          //  Die();
        //}
    }

    void FixedUpdate()
    {
      // zmiernenie rychlosti hrača
      Vector3 easeVelocity = rb2d.velocity;
      easeVelocity.y = rb2d.velocity.y;
      easeVelocity.z = 0.0f;
      easeVelocity.x *= 0.75f;

      // pohyba hrača horizontalne - A a D 
      float h = Input.GetAxis("Horizontal"); // A,D, R_arrow (+1) L_arrow (-1)
      // aby nevznikalo zrychlenie hrača
      if(grounded) // fixnutie trenia hrača na osi X 
      {
          rb2d.velocity = easeVelocity;
      }
      rb2d.AddForce((Vector2.right * speed )* h);
      // limitovanie rychlosti hrača
      if(rb2d.velocity.x > maxSpeed) // aby nebola prekročena max rychlosť na osi x
      {
          rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);       
      }
      if(rb2d.velocity.x < -maxSpeed) // aby nebola prekročena max rychlosť na osi y
      {
          rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
      }

    }
    void Die2() // GAMEOVER
    {
        Instantiate(respawn); // efekt
        SceneManager.LoadScene(1);
     
        // game over = 1
        // level 1= 0
        /*  if (curHealth <= 0)
          {       
              SceneManager.LoadScene(0);
          }
          curLives -= 1;
          if (curLives <=0)
          {
              SceneManager.LoadScene(1);
          }   */

    }

    void Die() // nacita sa aktualna scena
    {
        // ked zomrieme - restart     
        //Application.LoadLevel(1);
        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(1);
    }

    public void Damage(int dmg)  // damage pre HROTY
    {
      if (curHealth < dmg)
      {
          dmg = curHealth;
      }
      curHealth -= dmg;
    }

    public void Damage2(int dmg2)  // damage pre RYBU 
    {
      if (curHealth < dmg2)
      {
          dmg2 = curHealth;
      }
      curHealth -= dmg2;
    }

    public void Damage3(int dmg3)  // damage pre HROTY 2 
    {
        if (curHealth < dmg3)
        {
            dmg3 = curHealth;
        }
        curHealth -= dmg3;
    }

    // knockback pri hite od nepriatela
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {

        float timer = 0;

        while (knockDur > timer)
        {

            timer += Time.deltaTime;

            rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y + knockbackPwr, transform.position.z));

        }

        yield return 0;
    }

    // Kolizie OnTriggerEnter2D
    void OnTriggerEnter2D(Collider2D col) // kolizia s mincou hudba + destroy + pridanie bodu
    {
      if(col.CompareTag("Minca"))
      {
          zvukMinca.Play();            
          Destroy(col.gameObject);
          gm.points += 1;
      }
      if (col.CompareTag("Minca2")) // pre mincu 2
      {
          zvukMinca2.Play();
          Destroy(col.gameObject);
          gm.points += 3;
      }
        if (col.CompareTag("Ryba")) // pre rybu
        {
            zvukHit.Play();         
        }
     
    }

    public void GiveHealth(int health) // pridavanie zdravia - Healthpacks
     
    {
      curHealth += health;
    }

    private void Slide()
    {
        Vector2 move;
        //move.y = speed;
        // move.x = 0.0f;
        // pre pohyb doprava dolava
        move.x = speed;
        move.y = 0.0f;

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



} // koniec
