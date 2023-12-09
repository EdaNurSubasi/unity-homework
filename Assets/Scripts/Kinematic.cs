using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : SteeringOutput
{
    private Vector3 position;
    private Vector3 velocity;
    private float orientation;
    private float rotation;

    public Kinematic() { }



    public void update(SteeringOutput steeringOutput, float time)
    {
        // Update the position and orientation
        position += velocity * time;
        orientation += rotation * time;

        // and the velocity and rotation
        velocity = new Vector3(velocity.x + steeringOutput.Linear.x * time, velocity.y + steeringOutput.Linear.y * time);
        // velocity += steeringOutput.Linear * time;
        rotation += steeringOutput.Angular * time;

    }

    public float newOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            return Mathf.Atan2(-velocity.x, velocity.y);
        }

        return current;
    }

    public Vector3 Position { get => position; set => position = value; }
    public Vector3 Velocity { get => velocity; set => velocity = value; }
    public float Orientation { get => orientation; set => orientation = value; }
    public float Rotation { get => rotation; set => rotation = value; }
}
