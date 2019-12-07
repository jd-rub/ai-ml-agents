using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detonation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("entferneExplo", 0.9f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //explosionen halten ca 1 sek 
    private void entferneExplo()
    {
        Destroy(gameObject);
    }


    //treffe den Spieler
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "player_1")
        {
            GameObject player_1 = GameObject.Find("player_1");
            player_1.GetComponent<player_1>().hit(); 
        }
    }
}
