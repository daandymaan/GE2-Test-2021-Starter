﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : SteeringBehaviour
{

    public Path path;

    Vector3 nextWaypoint;

    public void Start()
    {
        
    }


    public override Vector3 Calculate()
    {
        nextWaypoint = path.NextWaypoint();
        if (Vector3.Distance(transform.position, nextWaypoint) < 3)
        {
            path.AdvanceToNext();
        }

        if (!path.looped && path.IsLast())
        {
            return dog.ArriveForce(nextWaypoint, 20);
        }
        else
        {
            return dog.SeekForce(nextWaypoint);
        }
    }
}
