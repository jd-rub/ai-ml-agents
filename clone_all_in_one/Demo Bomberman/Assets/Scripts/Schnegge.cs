using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schnegge : Perk
{
    Player player;
    // Update is called once per frame
    void Update()
    {
          
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Stop", 10);
            player = collision.GetComponent<Player>();
            player.hasSnail = true;
            player.hasCoffee = false;
            gameObject.SetActive(false);
        }
    }

    private void Stop()
    {
        player.hasSnail = false;
        Destroy(this.gameObject);
    }
}
