using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombe : MonoBehaviour
{
    //private int explosionlength;  //hab ich erstmal rausgenommen und direkt in die explosion gepackt, sollte später hier implementiert werden

    //prefab der explosion
    public GameObject explosion;

    // Start is called before the first frame update

    //Bomben explodieren nach 2 sek
    void Start()
    {
        //explosionlength = 4;
        InvokeRepeating("Explode", 2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode() {
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
