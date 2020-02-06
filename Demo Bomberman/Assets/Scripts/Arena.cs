using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arena : MonoBehaviour
{
    //länge und breite des spielfeldes und anzahl der bomben die spawnen
    public static int width = 17;
    public static int height = 13;
    public int players_alive;

    public List<GameObject> players;

    public bool playMode;

    //Represents the grid of the arena, 0 is a floor tile, 1 a wall, 2 a barrel and 3 a bomb, 4 a Perk
    public enum GridValues { FLOOR = 0, WALL = 1, BARREL = 2, BOMB = 3, PERK = 4, DETONATION = 7 }
    public int[,] grid = new int[width, height];

    // Start is called before the first frame update
    void Start()
    {
        players = new List<GameObject>();
        players_alive = 2;
        if (this.playMode)
        {
            players.Add(this.transform.GetChild(0).GetComponent<Player>().gameObject);
            players.Add(this.transform.GetChild(1).GetComponent<Player>().gameObject);
        }
        else
        {
            players.Add(this.transform.parent.GetChild(0).GetComponent<Player>().gameObject);
            players.Add(this.transform.parent.GetChild(1).GetComponent<Player>().gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (players_alive <= 1)
        {
            Reset();
        }

        if (Input.GetAxisRaw("Cancel") == 1)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void Reset()
    {
        if (this.playMode)
        {
            StartCoroutine(PlayModeReloadScene(1));
        }
        else
        {
            GetComponentInParent<ResetGame>().Reset_Game(this.transform.position);
            Destroy(gameObject);
        }
        
    }

    //coroutine die nach 1sek nach dem treffer ausgeführt wird und den spieler automatisch resettet
    IEnumerator PlayModeReloadScene(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("PlayableScene");
    }
}