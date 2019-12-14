using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spielfeld : MonoBehaviour
{
    //länge und breite des spielfeldes und anzahl der bomben die spawnen
    private static int breite = 17;
    private static int hoehe = 13;
    public int nrBomben = 3;
    private int lastBombSpawn = 0;

    //prefab der Bombe
    public GameObject bomb;
    public GameObject shoe;

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("SpawnBomben", 0f, 4f);

    }

// Update is called once per frame
    void Update()
    {
        if (Time.frameCount == lastBombSpawn + 180)
        {
            SpawnBomben();
            SpawnPerk();
            lastBombSpawn = Time.frameCount;
        }
    }


    //spawne random alle 4 sekunden einige bomben, Anzahl oben definiert
    void SpawnBomben()
    { 
        for(int i = 0; i < nrBomben; i++)
        {
            Vector2 position = new Vector2(
                this.transform.position.x + Random.Range(1, breite-1), 
                this.transform.position.y + Random.Range(1, hoehe-1));
            Instantiate(bomb, position, Quaternion.identity);
        }
    }
    void SpawnPerk()
    {
        Vector2 position = new Vector2(
            this.transform.position.x + Random.Range(1, breite - 1),
            this.transform.position.y + Random.Range(1, hoehe - 1));
        Instantiate(shoe, position, Quaternion.identity);
    }
}
