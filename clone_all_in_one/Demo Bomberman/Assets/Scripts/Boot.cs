using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : Perk
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Player>().base_speed < 0.2f)
            {
                collision.gameObject.GetComponent<Player>().base_speed += 0.01f;
            }
            Destroy(this.gameObject);
        }
    }
}
