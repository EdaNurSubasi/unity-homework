using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringOutput
{
    private Vector2 linear;
    private float angular;

    public SteeringOutput() { }

    public Vector2 Linear { get => linear; set => linear = value; }
    public float Angular { get => angular; set => angular = value; }
}
