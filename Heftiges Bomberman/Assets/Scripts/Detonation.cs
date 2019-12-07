using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EntferneExplo", 0.9f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //explosionen halten ca 1 sek 
    private void EntferneExplo()
    {
        Destroy(gameObject);
    }


    //treffe den Spieler
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player_1")
        {
            Player_1 p1 = col.gameObject.GetComponent<Player_1>();
            p1.Hit();
        }
    }
}
