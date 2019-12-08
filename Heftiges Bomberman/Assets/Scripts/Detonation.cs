using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonation : MonoBehaviour
{
    private int createdFrame;
    // Start is called before the first frame update
    void Start()
    {
        createdFrame = Time.frameCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount == createdFrame + 60)
        {
            RemoveExplosion();
        }
    }


    //explosionen halten ca 1 sek 
    private void RemoveExplosion()
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
