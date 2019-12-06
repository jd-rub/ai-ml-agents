using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombe : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isActive;
    private int explosionlength;
    private float x, y;
    private BoxCollider2D boxcollider_x, boxcollider_y;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcollider_x = gameObject.AddComponent<BoxCollider2D>();
        boxcollider_y = gameObject.AddComponent<BoxCollider2D>();
        x = boxcollider_x.size.x;
        y = boxcollider_y.size.y;
        isActive = false;
        explosionlength = 4;
        rb.position = new Vector2(((Random.Range(1,15)-7.5f)*0.67f), ((Random.Range(1,15)-7.5f)*0.67f));
        InvokeRepeating("Explode", 3f, 4f);
        InvokeRepeating("Respawn", 4f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onCollisionEnter2D(Collision2D col) {
        Debug.Log("HIT");
        if (col.gameObject.name == "player_1") {
            GameObject player_1 = GameObject.Find("player_1");
            if (isActive) {
                player_1.GetComponent<player_1>().Reset();
                Debug.Log("ACTIVE");
            }
            else {
                Debug.Log("NACTIVE");
            }
        }
    }

    void Explode() {
        
        boxcollider_x.size = new Vector2((2*explosionlength+1)*67,boxcollider_x.size.y);
        
        boxcollider_y.size = new Vector2(boxcollider_y.size.x, (2*explosionlength+1)*67);

        isActive = true;
    }

    void Respawn() {
        boxcollider_x.size = new Vector2(x, y);
        boxcollider_y.size = new Vector2(x, y);
        rb.position = new Vector2(((Random.Range(1,15)-7.5f)*0.67f), ((Random.Range(1,15)-7.5f)*0.67f));
        isActive = false;
    }
}
