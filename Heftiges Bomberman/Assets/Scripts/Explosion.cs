using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawnt einfach nur die einzelnen Teilexplosionen, kann/sollte man eleganter machen 

public class Explosion : MonoBehaviour
{
    //stärke der Exlosion
    public int radius = 3;

    //prefabs der Explosionen
    public GameObject exploMitte;
    public GameObject exploAnfang;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 standort = this.transform.position;
        Instantiate(exploAnfang, standort, Quaternion.identity);
        for(int i = 1; i<= radius; i++)
        {
            Instantiate(exploMitte, standort + i*Vector2.up, Quaternion.Euler(0, 0, 90));
            Instantiate(exploMitte, standort - i*Vector2.up, Quaternion.Euler(0,0,270));
            Instantiate(exploMitte, standort + i*Vector2.left, Quaternion.Euler(0, 0, 180));
            Instantiate(exploMitte, standort - i*Vector2.left, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject);
    }
}
