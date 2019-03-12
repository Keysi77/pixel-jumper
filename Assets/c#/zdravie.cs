using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // pouzitie UI

public class zdravie : MonoBehaviour {
    public Sprite[] HeartSprite; // premenna

    public Image HeartUI;

    private Player player; // zdravie z hraca aj jeho premenne

    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();

    }
    void Update()
    {
        HeartUI.sprite = HeartSprite[player.curHealth]; 
        // zoberie zo scriptu Player hodnotu aktualneho zdravia, ktora je 5 
    }
}
