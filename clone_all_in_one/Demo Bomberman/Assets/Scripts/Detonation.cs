using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonation : MonoBehaviour
{
    private int createdFrame;
    private ArrayList hitPlayers;
    private Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(transform.localPosition.x, transform.localPosition.y);
        GetComponentInParent<Arena>().grid[(int)position.x, (int)position.y] = 7;
        createdFrame = Time.frameCount;
        gameObject.tag = "Explosion";
        hitPlayers = new ArrayList();
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


    //triff den Spieler
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player player = col.GetComponent<Player>();
            player.GetComponent<BomberAgent>().AddReward(0.5f);
            if (!hitPlayers.Contains(player))
            {
                player.Hit();
                hitPlayers.Add(player);
            }
        }

        if (col.gameObject.tag == "Bomb")
        {
            if (col.gameObject.GetComponent<Bomb>().active)
            {
                col.gameObject.GetComponent<Bomb>().Explode();
            }
        }

        if (col.gameObject.tag == "Perk")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Barrel")
        {
            col.GetComponent<Barrel>().Hit();
        }
    }
}
