﻿using System.Collections;
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
    private bool invincible;
    public bool agent;

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
    private float speed;

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
        shield = invincible = false;
        oldPos = RoundPosition();

        if (agent)
        this.transform.parent.GetChild(1).GetComponent<Arena>().players.Add(this.transform.gameObject);
        else GetComponentInParent<Arena>().players.Add(this.transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
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
        //Horizontal Movement
        if (Input.GetAxisRaw(x_axis) != 0 && alive)
        {
            float input = Input.GetAxisRaw(x_axis);
            MoveHorizontal(input);
        }

        //Vertical Movement
        else if (Input.GetAxisRaw(y_axis) != 0 && alive)
        {
            float input = Input.GetAxisRaw(y_axis);
            MoveVertical(input);
        }

        //Planting a bomb
        if ((Input.GetAxisRaw(input_bomb) == 1 || (RoundPosition() != oldPos && isOnCrack)) && alive)
        {
            if (!button_down || isOnCrack)
            {
                PlaceBomb();
                button_down = true;
            }
        }

        if (Input.GetAxisRaw(input_bomb) == 0)
        {
            button_down = false;
        }

        oldPos = RoundPosition();

    }

    public void PlaceBomb()
    {
        if (activeBombs < maxBombs)
        {
            GameObject bomb = Instantiate(bombe, RoundPosition(), Quaternion.identity);
            bomb.GetComponent<Bomb>().SetOwner(this.gameObject);
            activeBombs++;
            bomb.transform.parent = this.transform.parent.transform;
        }
    }

    public void MoveHorizontal(float direction)
    {
        rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, direction * 90.0f - 90f));
        rb.position = rb.position + Vector2.right * direction * speed;
    }

    public void MoveVertical(float direction)
    {
        rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, direction * 90.0f));
        rb.position = rb.position + Vector2.up * direction * speed;
    }



    //wenn der Spieler getroffen wird
    public void Hit()
    {
        if (!shield && !invincible)
        {
            alive = false;
            this.GetComponent<SpriteRenderer>().sprite = getroffen;
            StartCoroutine(ExecuteAfterTime(1));
        }
        else
        {
            invincible = true;
            gameObject.layer = LayerMask.NameToLayer("Invincible_player");
            shield = false;
            Invoke("Inv_frames", 1.2f);
        }
    }


    //coroutine die nach 1sek nach dem treffer ausgeführt wird und den spieler automatisch resettet
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        //GameObject.Find("Spielfeld").GetComponent<Arena>().players_alive--;
        GetComponentInParent<Arena>().players_alive--;
    }

    private Vector2 RoundPosition()
    {
        return new Vector2(Mathf.Round(this.transform.position.x), Mathf.Round(this.transform.position.y));
    }

    public bool GetAlive()
    {
        return alive;
    }

    private void Inv_frames()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
        invincible = false;
    }
}