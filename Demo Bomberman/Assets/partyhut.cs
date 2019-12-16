using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partyhut : MonoBehaviour
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
            Invoke("stop", 10);
            player = collision.GetComponent<Player>();
            collision.GetComponent<Player>().isOnCrack = true;
        }
        gameObject.SetActive(false);
    }

    public void stop()
    {
        player.isOnCrack = false;
        Destroy(this.gameObject);
    }
}
