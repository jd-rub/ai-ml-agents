﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningArena : Arena
{

    public GameObject[] perks;
    public ArrayList perkList;
    public GameObject perk;
    public GameObject bomb;
    public GameObject[] bombs;
    public ArrayList bombList;
    int frame;
    void Start()
    {
        
        perkList = new ArrayList();
        bombList = new ArrayList();
        grid = this.GetComponent<Arena>().grid;
        
        //zufällige Position des Players
        this.transform.parent.GetChild(0).GetComponent<Player>().transform.position = GetRandomPlayerPosition();
        this.transform.parent.GetChild(1).GetComponent<Player>().transform.position = GetRandomPlayerPosition();
    }
    // Update is called once per frame
    void Update()
    {
        frame++;
    }

    // SpawnPerk and SpawnBomb were used for earlier learning testing
    GameObject SpawnPerk()
    {
        int x, y;
        do
        {
            x = Random.Range(width/4, width*3/4);
            y = Random.Range(height/4, height*3/4);
        } while (grid[x, y] != (int)Arena.GridValues.FLOOR);
        GameObject perk = Instantiate(perks[Random.Range(0, perks.Length)], new Vector2(this.transform.position.x + x, this.transform.position.y + y), Quaternion.identity);
        perk.layer = LayerMask.NameToLayer("Invincible_perk");
        perk.transform.parent = this.transform;
        perk.GetComponent<Perk>().instantiated = frame;
        return perk;
    }

    GameObject SpawnBomb()
    {
        int x, y;
        do
        {
            x = Random.Range(0, width);
            y = Random.Range(0, height);
        } while (grid[x, y] != (int)Arena.GridValues.FLOOR);
        GameObject bomb_spawn = Instantiate(bomb, new Vector2(this.transform.position.x + x, this.transform.position.y + y), Quaternion.identity);
        bomb_spawn.transform.parent = this.transform;
        bomb_spawn.GetComponent<Bomb>().SetOwner(this.transform.GetChild(4).gameObject);
        return bomb_spawn;
    }

    Vector2 GetRandomPlayerPosition()
    {
        int x, y;
        do
        {
            x = Random.Range(width / 4, width * 3 / 4);
            y = Random.Range(height / 4, height * 3 / 4);
        } while (grid[x, y] != (int)Arena.GridValues.FLOOR);
        frame = 0;

        return new Vector2(this.transform.position.x + x, this.transform.position.y + y);
    }

    public void DestroyPerk(GameObject g)
    {
        perkList.Remove(g);
    }
}
