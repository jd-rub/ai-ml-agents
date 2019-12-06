using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_1 : MonoBehaviour
{
    private Rigidbody2D rb;
    bool canMoveX, canMoveY;
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
            rb.position = rb.position + new Vector2(0, 0.1f);
            canMoveX = false;
        }
        if (Input.GetKey("a") && canMoveX) {
            rb.transform.rotation = Quaternion.Euler(new Vector3(0,0,180.0f));
            rb.position = rb.position + new Vector2(-0.1f, 0);
            canMoveY = false;
        }
        if (Input.GetKey("s") && canMoveY) {
            rb.transform.rotation = Quaternion.Euler(new Vector3(0,0,270.0f));
            rb.position = rb.position + new Vector2(0, -0.1f);
            canMoveX = false;
        }
        if (Input.GetKey("d") && canMoveX) {
            rb.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            rb.position = rb.position + new Vector2(0.1f, 0);
            canMoveY = false;
        }
        if (Input.GetKeyUp("w") || Input.GetKeyUp("s")) {
            canMoveX = true;
        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d")) {
            canMoveY = true;
        }
    }

    public void Reset() {
        rb.position = new Vector2(0,0);
    }
}
