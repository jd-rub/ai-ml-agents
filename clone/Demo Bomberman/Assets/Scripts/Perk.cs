using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perk : MonoBehaviour
{
    public int instantiated;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Perk";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
