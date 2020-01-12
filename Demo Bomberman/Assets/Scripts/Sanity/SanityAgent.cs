using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class SanityAgent : Agent
{
    private float rnd;

    public void Start()
    {
        this.rnd = 1;
    }

    public override void CollectObservations()
    {
        AddVectorObs(rnd);
    }

    public override void AgentAction(float[] vectorAction)
    {
        float dist = Mathf.Sqrt(Mathf.Pow(rnd - vectorAction[0], 2));
        Debug.Log("Rnd: " + rnd + ". AgentPrediction: " + vectorAction[0]);
        if (dist != 0)
        {
            SetReward(-dist);
        }
        else
        {
            SetReward(1f);
            this.Done();
        }
        //
    }

    public override void AgentReset()
    {
        //this.rnd = Random.value;
    }
}
