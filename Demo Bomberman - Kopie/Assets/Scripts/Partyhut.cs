using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partyhut : MonoBehaviour
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Stop", 10);
            player = collision.GetComponent<Player>();
            player.isOnCrack = true;
            gameObject.SetActive(false);

            player.playerAgent.AddReward(0.5f);
        }
    }

    public void Stop()
    {
        player.isOnCrack = false;
        Destroy(this.gameObject);
    }
}
