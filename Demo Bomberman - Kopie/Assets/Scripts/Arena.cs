using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arena : MonoBehaviour
{
    //länge und breite des spielfeldes und anzahl der bomben die spawnen
    private static int width = 17;
    private static int height = 13;
    public int players_alive;
    public GameObject[] perks;
    private bool isPerkPlaced;

    public int[,] grid = new int[width, height];

    //prefab der Bombe
    public GameObject bombe;


    // Start is called before the first frame update
    void Start()
    {
        players_alive = 2;
        isPerkPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (players_alive <= 1)
        {
            Reset();
        }
        if (!isPerkPlaced) //is needed because otherwise perks can spawn in walls as not all walls have finished registration by this point
        {
            SpawnRandomPerk();
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void SpawnRandomPerk()
    {
        int rndIndex = Random.Range(0, perks.Length);
        GameObject perk = perks[rndIndex];
        int xPosition, yPosition;
        do
        {
            xPosition = Random.Range((int)this.transform.position.x, (int)this.transform.position.x + width);
            yPosition = Random.Range((int)this.transform.position.y, (int)this.transform.position.y + height);
        } while (grid[xPosition, yPosition] != 0);
        Instantiate(perk, new Vector2(xPosition, yPosition), new Quaternion(0, 0, 0, 0));
        isPerkPlaced = true; 
    }
}