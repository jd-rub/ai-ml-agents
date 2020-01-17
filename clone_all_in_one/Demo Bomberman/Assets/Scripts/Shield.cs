using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Perk
{

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
  
    }



    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().shield = true;

            this.transform.parent.GetComponent<LearningArena>().DestroyPerk(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
