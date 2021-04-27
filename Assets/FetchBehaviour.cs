using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchBehaviour : SteeringBehaviour
{
    public GameObject targetBall;
    public Vector3 ballPos;
    public void OnDrawGizmos()
    {
        if (Application.isPlaying && isActiveAndEnabled)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, ballPos);
        }
    }

    void OnEnable()
    {
        dog.GetComponent<AudioSource>().Play();
    }

    public override Vector3 Calculate()
    {
        ballPos = targetBall.transform.position;
        return dog.SeekForce(ballPos);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
