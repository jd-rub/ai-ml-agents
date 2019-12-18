using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove_invincibility : MonoBehaviour
{

    private Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Not_Invincible", 1.2f);
        position = new Vector2(transform.localPosition.x, transform.localPosition.y);
        GetComponentInParent<Arena>().grid[(int)position.x, (int)position.y] = 4;
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

    public void OnDestroy()
    {
        if (GetComponentInParent<Arena>() != null)
        {
            GetComponentInParent<Arena>().grid[(int)position.x, (int)position.y] = 0;
        }

    }
}
