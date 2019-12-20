using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using System;

public class BomberAgent : Agent
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void AgentReset()
    {
        Debug.Log("Agent Reset");
        player.GetComponentInParent<Arena>().Reset();
    }

    public override void AgentAction(float[] vectorAction)
    {
        switch (vectorAction[0])
        {
            case 0: player.MoveHorizontal(-1);
                break;
            case 1: player.MoveHorizontal(1);
                break;
            case 2: player.MoveVertical(-1);
                break;
            case 3: player.MoveVertical(1);
                break;
        }
        //if (vectorAction[1] == 1)
        //{
          //  player.PlaceBomb();
        //}
        if (!(player.GetAlive()))
        {
            Done();
        }
    }

    public override float[] Heuristic()
    {
        float[] output = new float[2] {-1, -1};
        if (Input.GetKey("g"))
        {
            output[0] = 0;
        }
        else if (Input.GetKey("j"))
        {
            output[0] = 1;
        }
        else if (Input.GetKey("h"))
        {
            output[0] = 2;
        }
        else if (Input.GetKey("z"))
        {
            output[0] = 3;
        }
        if (Input.GetKey("u"))
        {
            output[1] = 1;
        }
        return output;
    }

    public override void AgentOnDone()
    {
        Debug.Log("Agent Done");
        base.AgentOnDone();
    }

}
