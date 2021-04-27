using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
    public float weight = 1.0f;
    public Vector3 force;

    [HideInInspector]
    public DogController dog;

    public void Awake()
    {
        dog = GetComponent<DogController>();
    }

    public abstract Vector3 Calculate();
}
