using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject feld;

    public GameObject block;

    public GameObject[] perks;

    // Start is called before the first frame update
    void Start()
    {
        feld = this.transform.parent.transform.parent.gameObject;
        int x = (int) (transform.position.x - feld.transform.position.x);
        int y = (int) (transform.position.y - feld.transform.position.y);
        feld.GetComponent<Arena>().grid[x, y] = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        GameObject tile = Instantiate(block, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        if (Random.Range(0, 4) == 1)
        {
            GameObject perk = Instantiate(perks[Random.Range(0, perks.Length)], this.transform.position, Quaternion.identity);
            perk.layer = LayerMask.NameToLayer("Invincible_perk");
            perk.transform.parent = this.transform.parent.transform.parent.transform;
        }
        tile.transform.parent = this.transform.parent.transform.parent;
        Destroy(this.gameObject);
    }
}
