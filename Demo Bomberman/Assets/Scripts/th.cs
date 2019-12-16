using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class th : MonoBehaviour
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
            if (collision.gameObject.GetComponent<Player>().speed < 0.2f)
            {
                collision.gameObject.GetComponent<Player>().speed += 0.01f;
            }
            Destroy(this.gameObject);
        }
        Debug.Log("lol");
    }
}
