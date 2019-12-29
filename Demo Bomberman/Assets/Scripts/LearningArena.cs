using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningArena : Arena
{
    private bool perkSpawned = false;
    public GameObject[] perks;
    void Start()
    {
        
        grid = this.GetComponent<Arena>().grid;
        //Debug.Log(grid[8,12]);
    }
    // Update is called once per frame
    void Update()
    {
        if (!perkSpawned)
        {
            int x, y;
            do
            {
                x = Random.Range(0, width);
                y = Random.Range(0, height);
            } while (grid[x, y] != 0);
            SpawnPerk(x,y);
            //Debug.Log("x: " + x + ", y: " + y + ", grid:" + grid[x,y]);
        }
    }

        void SpawnPerk(int x, int y)
    {
        GameObject perk = Instantiate(perks[Random.Range(0, perks.Length)], new Vector2(this.transform.position.x + x, this.transform.position.y + y), Quaternion.identity);
        perk.layer = LayerMask.NameToLayer("Invincible_perk");
        perk.transform.parent = this.transform;
        perkSpawned = true;
    }
}
