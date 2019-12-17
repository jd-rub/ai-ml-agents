using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private Arena arena;
    // Start is called before the first frame update
    void Start()
    {
        arena = GetComponentInParent<Arena>();
        int x = (int) (transform.position.x - arena.transform.position.x);
        int y = (int) (transform.position.y - arena.transform.position.y);
        arena.grid[x, y] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
