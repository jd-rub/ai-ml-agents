using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonation : MonoBehaviour
{
    private int createdFrame;
    private Vector2 position;
    public int owner;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(transform.localPosition.x, transform.localPosition.y);
        this.transform.parent.GetComponent<Arena>().grid[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)] = (int)Arena.GridValues.DETONATION;
        createdFrame = Time.frameCount;
        gameObject.tag = "Explosion";
    }

    private void FixedUpdate()
    {
        // Explosionen halten ca 1 sek 
        if (Time.frameCount >= createdFrame + 59)
        {
            RemoveExplosion();
        }
    }


    private void RemoveExplosion()
    {
        this.transform.parent.GetComponent<Arena>().grid[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)] = (int)Arena.GridValues.FLOOR;
        Destroy(gameObject);
    }


    //triff den Spieler
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player player = col.GetComponent<Player>();
            if (!player.playMode)
            {
                if (player.name == "player_1")
                {
                    if (owner == 1)
                    {
                        Debug.Log("player1 Hit yourself");
                        player.GetComponent<BomberAgent>().AddReward(-3f);
                    }
                    else
                    {
                        Debug.Log("player2 Hit player1");
                        player.GetComponent<BomberAgent>().AddReward(-1.5f);

                    }
                }
                else if (player.name == "player_2")
                {
                    if (owner == 2)
                    {
                        Debug.Log("player2 Hit yourself");
                        player.GetComponent<BomberAgentNoReset>().AddReward(-3f);
                    }
                    else
                    {
                        Debug.Log("player1 Hit player2");
                        player.GetComponent<BomberAgentNoReset>().AddReward(-1.5f);
                    }
                }
            }
            player.Hit();
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
