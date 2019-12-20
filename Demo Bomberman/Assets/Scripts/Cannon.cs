using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Perk
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<Player>().strength < 10)
            {
                collision.GetComponent<Player>().strength += 1;
                Destroy(this.gameObject);
            }
        }
    }
}
