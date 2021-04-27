using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBallBehaviour : MonoBehaviour
{
    public GameObject ballPrefab;
    public bool spaceReleased = true;
    public bool charging = false;
    public float chargeDuration = 0f;
    public float chargeMultiplier = 10;
    public float  minThrowPower = 10f;
    public float maxThrowPower = 200f;
    public float startTime = 0;

    void Start()
    {
    
    }

    void Update()
    {
        //Starts charging the throw
        if(Input.GetKeyDown(KeyCode.Space))
        {
            startTime = Time.time;
        }

        //Release and throws ball 
        if(Input.GetKeyUp(KeyCode.Space))
        {
            float heldTime = Time.time - startTime;
            Debug.Log("heldTime" + heldTime);
            heldTime *= chargeMultiplier;
            float throwPower = Mathf.Clamp(heldTime, minThrowPower, maxThrowPower);
            throwBall(throwPower);
            heldTime = 0;

        }
    }

    //Throws the ball at the charge distance
    private void throwBall(float throwPower)
    {
        Debug.Log("Throw Power:" + throwPower);
        if(ballPrefab != null){
            GameObject ball = Instantiate(ballPrefab);
            ball.transform.position = transform.position;
            Vector3 rotation = ball.transform.rotation.eulerAngles;
            ball.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * throwPower, ForceMode.Impulse);
        }
    }
}
