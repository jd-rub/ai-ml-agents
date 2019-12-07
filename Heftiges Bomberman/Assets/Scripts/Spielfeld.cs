using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spielfeld : MonoBehaviour
{
    //länge und breite des spielfeldes und anzahl der bomben die spawnen
    private static int breite = 17;
    private static int hoehe = 13;
    public int nrBomben = 3;

    //prefab der Bombe
    public GameObject bombe;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBombe", 0f, 4f);
    }

// Update is called once per frame
    void Update()
    {
        
    }


    //spawne random alle 4 sekunden einige bomben, Anzahl oben definiert
    void SpawnBombe()
    { 
        for(int i = 0; i < nrBomben; i++)
        {
            Vector2 position = new Vector2(
                this.transform.position.x + Random.Range(1, breite-1), 
                this.transform.position.y + Random.Range(1, hoehe-1));
            Instantiate(bombe, position, Quaternion.identity);
        }
    }
}
