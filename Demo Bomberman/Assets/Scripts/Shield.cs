using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Perk
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().shield = true;
            Destroy(this.gameObject);
        }
    }
}
