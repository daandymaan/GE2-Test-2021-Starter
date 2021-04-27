using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBallBehaviour : SteeringBehaviour
{
    public GameObject targetBall;
    void OnEnable()
    { 
        GameObject dogMouth =  transform.Find("dog").Find("ballAttach").gameObject;
        targetBall.GetComponent<Rigidbody>().isKinematic = true;
        targetBall.GetComponent<Rigidbody>().useGravity = false;
        targetBall.transform.SetParent(dogMouth.transform);
        targetBall.transform.position = dogMouth.transform.position;
    }

    public override Vector3 Calculate()
    {
        return dog.ArriveForce(dog.dogOwner.transform.position);
    }

    void Update()
    {
    
    }
}
