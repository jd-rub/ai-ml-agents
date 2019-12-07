using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_1 : MonoBehaviour
{
    private Rigidbody2D rb;
    bool canMoveX, canMoveY;
    public float speed;
    
    //verschiedene sprites für den spieler
    public Sprite normal;
    public Sprite getroffen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMoveX = canMoveY = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") && canMoveY) {
            rb.transform.rotation = Quaternion.Euler(new Vector3(0,0,90.0f));
            rb.position = rb.position + Vector2.up * speed;
           // canMoveX = false;
        }
        else if (Input.GetKey("a") && canMoveX) {
            rb.transform.rotation = Quaternion.Euler(new Vector3(0,0,180.0f));
            rb.position = rb.position + Vector2.left * speed;
            //canMoveY = false;
        }
        else if (Input.GetKey("s") && canMoveY) {
            rb.transform.rotation = Quaternion.Euler(new Vector3(0,0,270.0f));
            rb.position = rb.position + Vector2.down * speed;
            //canMoveX = false;
        }
        else if (Input.GetKey("d") && canMoveX) {
            rb.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            rb.position = rb.position + Vector2.right * speed;
            //canMoveY = false;
        }
        //if (Input.GetKeyUp("w") || Input.GetKeyUp("s")) {
        //    canMoveX = true;
        //}
        //if (Input.GetKeyUp("a") || Input.GetKeyUp("d")) {
        //    canMoveY = true;
        //}
    }


    //wenn der Spieler getroffen wird
    public void hit()
    {
        canMoveX = false;
        canMoveY = false;
        this.GetComponent<SpriteRenderer>().sprite = getroffen;
        StartCoroutine(ExecuteAfterTime(1));
    }


    //coroutine die nach 1sek nach dem treffer ausgeführt wird und den spieler automatisch resettet
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        rb.position = new Vector2(Random.Range(1, 16), Random.Range(1, 12));
        canMoveX = canMoveY = true;
        this.GetComponent<SpriteRenderer>().sprite = normal;
    }
}
