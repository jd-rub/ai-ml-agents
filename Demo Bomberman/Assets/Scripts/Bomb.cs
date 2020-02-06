using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool playMode = false;

    private List<GameObject> players;  //All Players, used for collision detection
    private GameObject owner; //owner of the bombe
    public bool active = true;

    //strength of the xplosion
    public int strength = 2;

    //prefabs der Explosionen
    public GameObject exploMitte;
    public GameObject exploAnfang;
    private Vector2 position;
    public int frame_created;

    private Arena arena;

    // Start is called before the first frame update
    void Start()
    {
        frame_created = 0;
        arena = this.transform.parent.GetComponent<Arena>();
        players = arena.players;

        foreach (GameObject player in players)
        {
            if ((player.GetComponent<BomberAgent>() != null) || (player.GetComponent<BomberAgentNoReset>() != null))
            {
                if (Mathf.Sqrt(Mathf.Pow(player.transform.position.x - this.transform.position.x, 2) + Mathf.Pow(player.transform.position.y - this.transform.position.y, 2)) < 3)
                {
                    if (player.GetComponent<BomberAgent>() != null)
                        player.GetComponent<BomberAgent>().AddReward(-0.01f);
                    else
                        player.GetComponent<BomberAgentNoReset>().AddReward(-0.01f);
                }
            }
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        }
        position = new Vector2(transform.localPosition.x, transform.localPosition.y);
        arena.grid[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)] = (int)Arena.GridValues.BOMB;
    }

    private void FixedUpdate()
    {
        frame_created++;
        //if a player is not on top of a bomb, activate the collision again
        foreach (GameObject player in players)
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
        explo = Instantiate(exploAnfang, (Vector2)this.transform.position, Quaternion.identity); explo.transform.parent = this.transform.parent;
        SpawnExplosion(Vector2.right, center, 0f);
        SpawnExplosion(Vector2.up, center, 90f);
        SpawnExplosion(Vector2.left, center, 180f);
        SpawnExplosion(Vector2.down, center, 270f);
        owner.GetComponent<Player>().activeBombs--;
        arena.grid[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)] = (int)Arena.GridValues.FLOOR;
        Destroy(gameObject);
    }

    private void SpawnExplosion(Vector2 direction, Vector2 center, float angle)
    {
        int[,] grid = arena.grid;

        for (int i = 1; i <= strength; i++)
        {
            Vector2 position = center + i * direction;
            if (grid[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)] == 1) break; //checks if there's a wall
            else if (grid[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)] == 2)
            {
                GameObject expo = Instantiate(exploMitte, (Vector2)this.transform.position + i * direction, Quaternion.Euler(0, 0, angle));
                expo.tag = "Explosion";
                if (owner.name == "player_1")
                    expo.GetComponent<Detonation>().owner = 1;
                else expo.GetComponent<Detonation>().owner = 2;
                expo.transform.parent = this.transform.parent;
                break;
            }
            else
            {
                GameObject expo = Instantiate(exploMitte, (Vector2)this.transform.position + i * direction, Quaternion.Euler(0, 0, angle));
                expo.transform.parent = this.transform.parent;
                if (owner.name == "player_1")
                    expo.GetComponent<Detonation>().owner = 1;
                else expo.GetComponent<Detonation>().owner = 2;
                expo.tag = "Explosion";
            }
        }
    }
}
