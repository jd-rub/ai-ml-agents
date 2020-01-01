using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningArena : Arena
{

    public GameObject[] perks;
    public ArrayList perkList;
    public GameObject perk;
    int frame;
    void Start()
    {
        
        perkList = new ArrayList();
        grid = this.GetComponent<Arena>().grid;
        int x, y;
        do
        {
            x = Random.Range(width/4, width*3/4);
            y = Random.Range(height/4, height*3/4);
        } while (grid[x, y] != 0);
        frame = 0;
        this.transform.parent.GetChild(0).GetComponent<Player>().transform.position = new Vector2(this.transform.position.x+x,this.transform.position.y+y);
        perk = SpawnPerk();
        //Debug.Log(grid[8,12]);
    }
    // Update is called once per frame
    void Update()
    {
        frame++;
/*        if ((frame%200 == 0) || (frame == 1))
        {
            perkList.Add(SpawnPerk());
        }
        foreach (GameObject perk in perkList)
        {
            if ((perk.GetComponent<Perk>().instantiated-frame)%200==0)
            {
                if ((frame-perk.GetComponent<Perk>().instantiated)>0) this.transform.parent.GetChild(0).GetComponent<BomberAgent>().AddReward(-0.005f);
            }
        }
  */  }

    GameObject SpawnPerk()
    {
        int x, y;
        /*do
        {
            x = Random.Range(width/4, width*3/4);
            y = Random.Range(height/4, height*3/4);
        } while (grid[x, y] != 0);*/
        x = 7;
        y = 3;
        GameObject perk = Instantiate(perks[Random.Range(0, perks.Length)], new Vector2(this.transform.position.x + x, this.transform.position.y + y), Quaternion.identity);
        perk.layer = LayerMask.NameToLayer("Invincible_perk");
        perk.transform.parent = this.transform;
        perk.GetComponent<Perk>().instantiated = frame;
        return perk;
    }

    public void DestroyPerk(GameObject g)
    {
        perkList.Remove(g);
    }
}
