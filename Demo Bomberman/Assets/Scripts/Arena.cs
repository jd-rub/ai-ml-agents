using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arena : MonoBehaviour
{
    //länge und breite des spielfeldes und anzahl der bomben die spawnen
    private static int breite = 17;
    private static int hoehe = 13;
    public int players_alive;

    public int[,] grid = new int[breite, hoehe];

    //prefab der Bombe
    public GameObject bombe;


    // Start is called before the first frame update
    void Start()
    {
        players_alive = 2;
    }

// Update is called once per frame
    void Update()
    {
        if (players_alive <= 1)
        {
            Reset();
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
