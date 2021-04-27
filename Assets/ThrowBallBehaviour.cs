using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBallBehaviour : MonoBehaviour
{
    public GameObject ballPrefab;
    public bool spaceReleased = true;
    public bool charging = false;
    public float chargeDuration = 0f;
    public float maxCharge = 2f;
    public float  minThrowPower = 10f;
    public float maxThrowPower = 200f;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && spaceReleased)
        {
            // throwBall();
            chargeDuration  = 0f;
            charging = true;
            spaceReleased = false;
        } 
        else if (charging && (Input.GetKeyDown(KeyCode.Space) || chargeDuration >= maxCharge))
        {
            float throwPower = Mathf.Lerp(minThrowPower, maxThrowPower, chargeDuration / maxCharge);
            throwBall(throwPower);
            ResetThrowValues();
        }

        if(charging)
        {
            chargeDuration += Time.deltaTime;
        }

        if(!spaceReleased)
        {
            spaceReleased = Input.GetKeyUp(KeyCode.Space);
        }

    }

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

    private void ResetThrowValues()
    {
        chargeDuration = 0f;
        charging = false;
    }
}
