using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class Bomb_plus : MonoBehaviour
{
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
            if (collision.GetComponent<Player>().maxBombs < 10)
            {
                collision.GetComponent<Player>().maxBombs += 1;
                collision.gameObject.GetComponentInChildren<Agent>().AddReward(1f);
                Destroy(this.gameObject);
            }
        }
    }
}
