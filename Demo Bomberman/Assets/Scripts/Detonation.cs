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
        // Explosionen halten ca 1 sek 
        if (Time.frameCount == createdFrame + 59)
        {
            RemoveExplosion();
        }
    }


    private void RemoveExplosion()
    {
        Destroy(gameObject);
    }



    //treffe den Spieler
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().hit(); 
        }

        Debug.Log(col.gameObject.name);

        if (col.gameObject.tag == "Bomb")
        {
            if (col.gameObject.GetComponent<Bomb>().active)
            {
                col.gameObject.GetComponent<Bomb>().Explode();
            }
        }
    }
}
