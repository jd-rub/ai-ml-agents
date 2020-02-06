using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    public GameObject spielfeld;
    public int id;
    public void Reset_Game(Vector3 position)
    {
        GameObject feld =  Instantiate(spielfeld, position, Quaternion.identity);
        feld.transform.parent = this.transform;        
    }
}
