using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    public GameObject spielfeld;
    public int id;
    private RenderTexture render;
    // Start is called before the first frame update
    void Start()
    {
        render = new RenderTexture(51,39,16);
        render.filterMode = FilterMode.Point;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset_Game(Vector3 position)
    {
        GameObject feld =  Instantiate(spielfeld, position, Quaternion.identity);
        feld.transform.parent = this.transform;

        GameObject cam = feld.transform.Find("AgentCam").gameObject;
        GameObject canvas = feld.transform.Find("Canvas").gameObject;

        cam.GetComponent<Camera>().targetTexture = render;
        canvas.GetComponent<RawImage>().texture = render;
        
    }

    public RenderTexture getRenderTexture()
    {
        return render;
    }
}
