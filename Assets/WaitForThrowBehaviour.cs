using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForThrowBehaviour : SteeringBehaviour
{
    public GameObject targetBall;
    void OnEnable()
    {
        if(GetComponent<DogController>().targetBall != null)
        {
            GameObject dogMouth =  transform.Find("dog").Find("ballAttach").gameObject;
            targetBall.transform.SetParent(null);
            targetBall.GetComponent<Rigidbody>().isKinematic = false;
            targetBall.GetComponent<Rigidbody>().useGravity = true;
            GetComponent<DogController>().targetBall.transform.tag = "Untagged";
            GetComponent<DogController>().targetBall = null;
            // Destroy(targetBall);
        }
    }

    public override Vector3 Calculate()
    {       
        transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation(GetComponent<DogController>().dogOwner.transform.position - transform.position ), Time.deltaTime );
        return dog.ArriveForce(dog.dogOwner.transform.position);
    }
}
