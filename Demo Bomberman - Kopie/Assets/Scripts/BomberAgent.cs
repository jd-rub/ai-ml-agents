using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class BomberAgent : Agent
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    public override void AgentReset()
    {
        
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
        if (vectorAction[1] == 1)
        {
            player.PlaceBomb();
        }
    }

    /*public override float[] Heuristic()
    {
        float[] output = new float[2] {-1, -1};
        if (Input.GetKey("up"))
        {
            output[0] = 0;
        }
        else if (Input.GetKey("left"))
        {
            output[0] = 1;
        }
        else if (Input.GetKey("down"))
        {
            output[0] = 2;
        }
        else if (Input.GetKey("right"))
        {
            output[0] = 3;
        }
        if (Input.GetKey("space"))
        {
            output[1] = 1;
        }
        return output;
    }*/

    public override void AgentOnDone()
    {
        base.AgentOnDone();
    }

}
