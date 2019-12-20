using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schnegge : MonoBehaviour
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
            player.isOnCannabis = true;
            player.isOnSpeed = false;
            gameObject.SetActive(false);

            player.playerAgent.AddReward(-1f);
        }
    }

    private void Stop()
    {
        player.isOnCannabis = false;
        Destroy(this.gameObject);
    }
}
