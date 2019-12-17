using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject feld;
    // Start is called before the first frame update
    void Start()
    {
        feld = GameObject.Find("Spielfeld");
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        feld.GetComponent<Arena>().grid[x, y] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
