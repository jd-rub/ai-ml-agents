using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private GameObject[] players;  //All Players, used for collision detection
    private GameObject owner; //owner of the bombe
    public bool active = true;

    //strength of the xplosion
    private int strength;

    //prefabs der Explosionen
    public GameObject exploMitte;
    public GameObject exploAnfang;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Explode", 2f, 4f); //bombs explode after 2 seconds
       
        //Find all Players and deactivate the collision
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if a player is not on top of a bomb, activate the collision again
        foreach(GameObject player in players)
        {
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x) > 1 || 
                Mathf.Abs(this.transform.position.y - player.transform.position.y) > 1)
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);
            }
        }
        Debug.Log(this.transform.parent.name);
    }

    public void SetOwner(GameObject owner)
    {
        this.owner = owner;
    }

    public void Explode() 
    {
        active = false;
        strength = owner.GetComponent<Player>().strength;
        Vector2 center = this.transform.position; //falls Bomben sich bewegen sollte man hier noch runden
        Instantiate(exploAnfang, center, Quaternion.identity);

        SpawnExplosion(Vector2.right, center, 0f);
        SpawnExplosion(Vector2.up, center, 90f);
        SpawnExplosion(Vector2.left, center, 180f);
        SpawnExplosion(Vector2.down, center, 270f);
        owner.GetComponent<Player>().activeBombs--;
        Destroy(gameObject);
    }

    private void SpawnExplosion(Vector2 direction, Vector2 center, float angle)
    {
        int[,] grid = GameObject.Find("Spielfeld").GetComponent<Arena>().grid;
        for (int i = 1; i <= strength; i++)
        {
            Vector2 position = center + i * direction;
            if (grid[(int)position.x, (int)position.y] == 1) break; //checks if there's a wall
            else
            {
                GameObject expo = Instantiate(exploMitte, center + i * direction, Quaternion.Euler(0, 0, angle));
                expo.tag = "Explosion";
            }
        }
    }
}
