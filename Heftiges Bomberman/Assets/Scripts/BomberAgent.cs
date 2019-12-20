using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class BomberAgent : Agent
{
    Player_1 player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player_1>();
    }

    public override void AgentReset()
    {
        
    }

    public override void AgentAction(float[] vectorAction)
    {
        switch (vectorAction[0])
        {
            case 0: player.MoveUp(); // W
                break;
            case 1: player.MoveLeft(); // A
                break;
            case 2: player.MoveDown(); // S
                break;
            case 3: player.MoveRight(); // D
                break;
        }
        if (player.isDead)
        {
            SetReward(-1.0f);
            Done();
        }
        
    }

    public override float[] Heuristic()
    {
        float[] output = new float[1] {-1};
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
        return output;
    }

    public override void AgentOnDone()
    {
        base.AgentOnDone();
    }

}
