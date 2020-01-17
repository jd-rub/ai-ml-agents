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


    //Represents the grid of the arena, 0 is a floor tile, 1 a wall, 2 a barrel and 3 a bomb, 4 a Perk
    public int[,] grid = new int[width, height];

    // Start is called before the first frame update
    void Start()
    {
        players = new List<GameObject>();
        players_alive = 2;
        players.Add(this.transform.GetChild(0).GetComponent<GameObject>());
        players.Add(this.transform.GetChild(1).GetComponent<GameObject>());
    }

    // Update is called once per frame
    void Update()
    {
        if (players_alive <= 1)
        {
            Reset();
        }
    }

    public void Reset()
    {
        //SceneManager.LoadScene("SampleScene");
        GetComponentInParent<ResetGame>().Reset_Game(this.transform.position);
        Destroy(gameObject);
    }
}