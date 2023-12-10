using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicWanderer : MonoBehaviour
{

    public GameObject character;
    public float maxSpeed = 1.0f;

    // The maximum rotation speed we’d like, probably should be smaller
    // than the maximum possible, for a leisurely change in direction.
    float maxRotation = 15.0f;

    private Vector3 position;
    private Vector3 velocity;
    private float orientation =1;
    private float rotation = 1;


    void Start()
    {
        character = GameObject.Find("Fugitive");
        velocity = new Vector3(rotation, orientation);
        position = new Vector3(1, 1);
    }

    void Update()
    {
        update(getSteering(), Time.deltaTime);
    }

    public void update(Kinematic steeringOutput, float time)
    {
        // Update the position and orientation
        position += maxSpeed * time * velocity.normalized;
        orientation += steeringOutput.Rotation * time;

        // and the velocity and rotation
        velocity = new Vector3(velocity.x + steeringOutput.Linear.x * time, velocity.y + steeringOutput.Linear.y * time);
        // velocity += steeringOutput.Linear * time;
        rotation += steeringOutput.Angular * time;

        character.transform.position = position;
        Quaternion newRotation = Quaternion.Euler(0.0f, steeringOutput.Rotation, 0.0f);
        
        //character.transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, orientation * Time.deltaTime); 
        character.transform.Translate(position);
        character.transform.Rotate(Vector3.up, steeringOutput.Rotation);
    }

    public float newOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            return Mathf.Atan2(-velocity.x, velocity.y);
        }

        return current;
    }

    public Kinematic getSteering()
    {
        Kinematic result = new();

        //Get velocity from the vector form of the orientation

        result.Velocity = new Vector3(character.transform.position.x + character.transform.position.x * maxSpeed, character.transform.position.y+character.transform.position.y * maxSpeed);
        //result.Velocity = maxSpeed * character.transform.rotation.;
        result.Rotation = (Random.Range(-150.0f, 150.0f)- Random.Range(-90.0f, 90.0f)) * maxRotation *Time.deltaTime;

        return result;
    }

    public GameObject Character { get => character; set => character = value; }
    public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
    public float MaxRotation { get => maxRotation; set => maxRotation = value; }
    public Vector3 Position { get => position; set => position = value; }
    public Vector3 Velocity { get => velocity; set => velocity = value; }
    public float Orientation { get => orientation; set => orientation = value; }
    public float Rotation { get => rotation; set => rotation = value; }
}
