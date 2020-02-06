using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using System;
using MLAgents.Sensor;

public class BomberAgentNoReset : Agent
{
    public Player player;
    private Vector3 startingPos;
    public int steps;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = new Vector3(-5, -5.8f, 5);
        steps = 0;
    }

    public override void AgentReset()
    {
        this.GetComponent<Player>().SetAlive(true);
        this.GetComponent<Player>().activeBombs = 0;
        this.transform.localPosition = startingPos;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Perk")
        {
            AddReward(0.15f);
        }
    }

    public override void CollectObservations()
    {
        int[,] grid = this.transform.parent.GetChild(2).GetComponent<Arena>().grid;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                AddVectorObs(grid[i, j]);
            }
        }
        AddVectorObs(this.transform.position);
        GameObject enemy = this.transform.parent.GetChild(0).gameObject;
        AddVectorObs(enemy.transform.position);
    }

    public override void AgentAction(float[] vectorAction)
    {
        switch ((int)Math.Ceiling(vectorAction[0]))
        {
            case 0:
                player.MoveHorizontal(-1);
                break;
            case 1:
                player.MoveHorizontal(1);
                break;
            case 2:
                player.MoveVertical(-1);
                break;
            case 3:
                player.MoveVertical(1);
                break;
            case 4:
                player.PlaceBomb();
                break;
        }
        steps++;
    }

    public override float[] Heuristic()
    {
        float[] output = new float[2] { -1, -1 };
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
        Debug.Log(GetReward());
        Debug.Log("Agent Done");
        base.AgentOnDone();
    }

}
