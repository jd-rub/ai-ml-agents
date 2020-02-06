using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public Arena feld;
    // Start is called before the first frame update
    void Start()
    {
        feld = GetComponentInParent<Arena>();
        int x = (int)this.transform.localPosition.x;
        int y = (int)this.transform.localPosition.y;
        feld.grid[x, y] = (int)Arena.GridValues.WALL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
