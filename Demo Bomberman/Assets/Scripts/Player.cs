using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    //player stats
    private bool alive;
    public float base_speed;
    public int id;
    public int maxBombs;
    public int activeBombs;
    public int strength;
    public bool shield;
    
    //verschiedene sprites für den spieler
    public Sprite normal;
    public Sprite getroffen;

    public GameObject bombe;

    //used for the movement
    private string x_axis;
    private string y_axis;
    private string input_bomb;
    private bool button_down;
    private Vector2 oldPos;
    public bool isOnCrack, isOnSpeed, isOnCannabis;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxBombs = 3;
        activeBombs = 0;
        x_axis = "move_x_" + id.ToString();
        y_axis = "move_y_" + id.ToString();
        input_bomb = "bomb_" + id.ToString();
        button_down = false;
        alive = true;
        isOnCrack = false;
        isOnSpeed = false;
        isOnCannabis = false;
        shield = false;
        oldPos = RoundPosition();
    }

    // Update is called once per frame
    void Update()
    {
        float speed;
        if (isOnSpeed)
        {
            speed = 0.3f;
        }
        else if (isOnCannabis)
        {
            speed = 0.05f;
        }
        else
        {
            speed = base_speed;
        }
        //Vertical Movement
        if (Input.GetAxisRaw(x_axis) != 0 && alive)
        {
            float input = Input.GetAxisRaw(x_axis);
            rb.transform.rotation = Quaternion.Euler(new Vector3(0,0,input * 90.0f -90f));
            rb.position = rb.position + Vector2.right * input * speed;
        }

        //Horizontal Movement
        else if (Input.GetAxisRaw(y_axis) != 0 && alive)
        {
            float input = Input.GetAxisRaw(y_axis);
            rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, input * 90.0f));
            rb.position = rb.position + Vector2.up * input * speed;
        }

        //Planting a bomb
        if ((Input.GetAxisRaw(input_bomb) == 1 || (RoundPosition() != oldPos && isOnCrack)) && alive)
        {
            if (!button_down || isOnCrack)
            {
                if (activeBombs < maxBombs)
                {
                    GameObject asdf = Instantiate(bombe, RoundPosition(), Quaternion.identity);
                    asdf.GetComponent<Bomb>().SetOwner(this.gameObject);
                    activeBombs++;
                }
                button_down = true;
            }
        }

        if(Input.GetAxisRaw(input_bomb) == 0)
        {
            button_down = false;
        }

        oldPos = RoundPosition();
        
    }


    //wenn der Spieler getroffen wird
    public void Hit()
    {
        if (!shield)
        {
            alive = false;
            this.GetComponent<SpriteRenderer>().sprite = getroffen;
            StartCoroutine(ExecuteAfterTime(1));
        }
        else shield = !shield;
    }


    //coroutine die nach 1sek nach dem treffer ausgeführt wird und den spieler automatisch resettet
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject.Find("Spielfeld").GetComponent<Arena>().players_alive--;
    }

    private Vector2 RoundPosition()
    {
        return new Vector2(Mathf.Round(this.transform.position.x), Mathf.Round(this.transform.position.y));
    }

    public bool GetAlive()
    {
        return alive;
    }
}
