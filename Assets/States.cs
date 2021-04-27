using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fetch : State
{
    public override void Enter()
    {
        owner.GetComponent<FetchBehaviour>().targetBall = owner.GetComponent<DogController>().targetBall;
        owner.GetComponent<FetchBehaviour>().enabled = true;
    }

    public override void Think()
    {
        if(owner.GetComponent<DogController>().targetBall != null)
        {
            Vector3 distanceFromBall = owner.GetComponent<DogController>().targetBall.transform.position - owner.transform.position;
            if(distanceFromBall.magnitude < 2)
            {
                owner.ChangeState(new ReturnBallToOwner());
            } 
        } 
        else 
        {
            owner.ChangeState(new WaitForBall());
        }
    }

    public override void Exit()
    {
        owner.GetComponent<FetchBehaviour>().enabled = false;
    }
}
public class ReturnBallToOwner: State
{
    public override void Enter()
    {
        owner.GetComponent<ReturnBallBehaviour>().targetBall = owner.GetComponent<DogController>().targetBall;
        owner.GetComponent<ReturnBallBehaviour>().enabled = true;
    }

    public override void Think()
    {
        Vector3 distanceFromOwner = owner.GetComponent<DogController>().dogOwner.transform.position - owner.transform.position;
        if(distanceFromOwner.magnitude < owner.GetComponent<DogController>().distanceFromGO)
        {
            owner.ChangeState(new WaitForBall());
        } 
    }

    public override void Exit()
    {
        owner.GetComponent<ReturnBallBehaviour>().enabled = false;
    }
}
public class WaitForBall: State 
{
    public override void Enter()
    {
        
        if(owner.GetComponent<DogController>().targetBall != null)
        {
            owner.GetComponent<WaitForThrowBehaviour>().targetBall = owner.GetComponent<DogController>().targetBall;
        }
        owner.GetComponent<WaitForThrowBehaviour>().enabled = true;
    }

    public override void Think()
    {
        if(owner.GetComponent<DogController>().targetBall != null)
        {
            owner.ChangeState(new Fetch());
        }
    }

    public override void Exit()
    {
        owner.GetComponent<WaitForThrowBehaviour>().enabled = false;
    }
}