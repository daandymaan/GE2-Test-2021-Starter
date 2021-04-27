using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailWagBehaviour : MonoBehaviour
{
    public float frequency = 1;
    public float amplitude = 40;
    public float theta = 0;
    void Start()
    {
        theta = 0;
    }

    void Update()
    {
        float tailSpeed = transform.parent.gameObject.GetComponent<DogController>().velocity.magnitude;
        float angle = Mathf.Sin(theta) * amplitude;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.up);
        transform.localRotation = q;
        theta += Mathf.PI * 2.0f * Time.deltaTime * frequency * tailSpeed;
    }
}

