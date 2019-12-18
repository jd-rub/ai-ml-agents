using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public GameObject spielfeld;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset_Game(Vector3 position)
    {
        GameObject feld =  Instantiate(spielfeld, position, Quaternion.identity);
        feld.transform.parent = this.transform;
    }
}
