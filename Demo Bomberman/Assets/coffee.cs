using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffee : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Perk";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("stop", 10);
            player = collision.GetComponent<Player>();
            player.isOnSpeed = true;
            player.isOnCannabis = false;
            gameObject.SetActive(false);
        }
    }

    private void stop()
    {
        player.isOnSpeed = false;
        Destroy(this.gameObject);
    }
}

