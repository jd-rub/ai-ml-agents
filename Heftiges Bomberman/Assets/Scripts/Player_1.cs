using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1 : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float defaultSpeed;
    private float speed;
    private Transform playingField;
    
    //verschiedene sprites für den spieler
    [SerializeField] private Sprite normal;
    [SerializeField] private Sprite getroffen;

    public bool isDead;
    private int deathFrame;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playingField = this.transform.parent.transform;
        speed = defaultSpeed;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")) {
            MoveUp();
        }
        else if (Input.GetKey("a")) {
            MoveLeft();
        }
        else if (Input.GetKey("s")) {
            MoveDown();
        }
        else if (Input.GetKey("d")) {
            MoveRight();
        }

        // Frame-dependent respawn after death
        if (isDead)
        {
            if (Time.frameCount == deathFrame + 60)
            {
                ResetPlayer();
            }
        }
    }

    public void MoveUp()
    {
        rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90.0f));
        rb.position += Vector2.up * speed;
    }

    public void MoveDown()
    {
        rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270.0f));
        rb.position += Vector2.down * speed;
    }

    public void MoveLeft()
    {
        rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180.0f));
        rb.position += Vector2.left * speed;
    }

    public void MoveRight()
    {
        rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        rb.position += Vector2.right * speed;
    }
    //wenn der Spieler getroffen wird
    public void Hit()
    {
        speed = 0;
        isDead = true;
        this.GetComponent<SpriteRenderer>().sprite = getroffen;
        deathFrame = Time.frameCount;
        // StartCoroutine(ExecuteAfterTime(1));
    }


    //coroutine die nach 1sek nach dem treffer ausgeführt wird und den spieler automatisch resettet
    //IEnumerator ExecuteAfterTime(float time)
    //{
    //    yield return new WaitForSeconds(time);

    //    ResetPlayer();
    //}

    void ResetPlayer()
    {
        rb.position = new Vector2(
            playingField.position.x + Random.Range(1, 16), 
            playingField.position.y + Random.Range(1, 12));
        speed = defaultSpeed;
        isDead = false;
        this.GetComponent<SpriteRenderer>().sprite = normal;
    }
}
