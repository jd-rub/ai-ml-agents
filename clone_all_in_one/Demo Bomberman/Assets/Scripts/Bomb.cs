using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private List<GameObject> players;  //All Players, used for collision detection
    private GameObject owner; //owner of the bombe
    public bool active = true;

    //strength of the xplosion
    private int strength;

    //prefabs der Explosionen
    public GameObject exploMitte;
    public GameObject exploAnfang;
    private Vector2 position;
    public int frame_created;


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Explode", 2f, 4f); //bombs explode after 2 seconds
        frame_created = 0;
        strength = 3;
        //Find all Players and deactivate the collision
        //players = GameObject.FindGameObjectsWithTag("Player");
        players = this.transform.parent.GetChild(2).GetComponent<Arena>().players;
        foreach (GameObject player in players)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        }
        position = new Vector2(transform.localPosition.x, transform.localPosition.y);
        GetComponentInParent<Arena>().grid[(int)position.x, (int) position.y] = 3;
    }

    // Update is called once per frame
    void Update()
    {
        frame_created++;

        //if a player is not on top of a bomb, activate the collision again
        foreach(GameObject player in players)
        {
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x) > 1 || 
                Mathf.Abs(this.transform.position.y - player.transform.position.y) > 1)
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);
            }
        }
        if (frame_created > 120)
            Explode();
    }

    public void SetOwner(GameObject owner)
    {
        this.owner = owner;
    }

    public void Explode() 
    {
        GameObject explo;
        active = false;
        strength = owner.GetComponent<Player>().strength;
        Vector2 center = this.transform.localPosition; //falls Bomben sich bewegen sollte man hier noch runden
        explo = Instantiate(exploAnfang, (Vector2) this.transform.position, Quaternion.identity); explo.transform.parent = this.transform.parent;

        SpawnExplosion(Vector2.right, center, 0f);
        SpawnExplosion(Vector2.up, center, 90f);
        SpawnExplosion(Vector2.left, center, 180f);
        SpawnExplosion(Vector2.down, center, 270f);
        owner.GetComponent<Player>().activeBombs--;
        GetComponentInParent<Arena>().grid[(int)position.x, (int)position.y] = 0;
        Destroy(gameObject);
    }

    private void SpawnExplosion(Vector2 direction, Vector2 center, float angle)
    {
        int[,] grid = GetComponentInParent<Arena>().grid;
        Transform field = GetComponentInParent<Transform>();
        
        for (int i = 1; i <= strength; i++)
        {
            Vector2 position = center + i * direction;
            if (grid[(int) (position.x), (int) (position.y)] == 1) break; //checks if there's a wall
            else if (grid[(int)position.x, (int)position.y] == 2)
            {
                GameObject expo = Instantiate(exploMitte, (Vector2) this.transform.position + i * direction, Quaternion.Euler(0, 0, angle));
                expo.tag = "Explosion";
                expo.transform.parent = this.transform.parent;
                break;
            }
            else
            {
                GameObject expo = Instantiate(exploMitte, (Vector2) this.transform.position + i * direction, Quaternion.Euler(0, 0, angle));
                expo.transform.parent = this.transform.parent;
                expo.tag = "Explosion";
            }
        }
    }
}
