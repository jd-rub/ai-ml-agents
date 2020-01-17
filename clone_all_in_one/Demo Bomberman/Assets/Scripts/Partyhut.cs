﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partyhut : Perk
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
            player.hasPartyHut = true;
            gameObject.SetActive(false);
        }
    }

    public void Stop()
    {
        player.hasPartyHut = false;
        Destroy(this.gameObject);
    }
}
