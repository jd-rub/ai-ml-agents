using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove_invincibility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Not_Invincible", 1.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Not_Invincible()
    {
        if (this.tag == "Perk")
        {
            this.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
