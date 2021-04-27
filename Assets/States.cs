using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This state allows the dog to fetch the ball
public class Fetch : State
{
    public override void Enter()
    {
        //Sets the target to be the ball
        owner.GetComponent<FetchBehaviour>().targetBall = owner.GetComponent<DogController>().targetBall;
        owner.GetComponent<FetchBehaviour>().enabled = true;
    }

    public override void Think()
    {
        //If the ball doesnt exist, wait for the ball at the owners side
        if(owner.GetComponent<DogController>().targetBall != null)
        {
            //Collect the ball if it near to the dog
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
//This allows the dog to return the ball to the owner
public class ReturnBallToOwner: State
{
    public override void Enter()
    {
        owner.GetComponent<ReturnBallBehaviour>().targetBall = owner.GetComponent<DogController>().targetBall;
        owner.GetComponent<ReturnBallBehaviour>().enabled = true;
    }

    //If the dog is near to the owner start the wait behaviour
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
        //If there is a ball set the target to be the ball
        if(owner.GetComponent<DogController>().targetBall != null)
        {
            owner.GetComponent<WaitForThrowBehaviour>().targetBall = owner.GetComponent<DogController>().targetBall;
        }
        owner.GetComponent<WaitForThrowBehaviour>().enabled = true;
    }

    //If a ball exists fetch 
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