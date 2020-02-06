using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_plus : Perk
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<Player>().maxBombs < 10)
            {
                collision.GetComponent<Player>().maxBombs += 1;
                Destroy(this.gameObject);
            }
        }
    }
}
