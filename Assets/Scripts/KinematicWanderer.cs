using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicWanderer : MonoBehaviour
{

    public GameObject character;
    float maxSpeed = 10.0f;

    // The maximum rotation speed we’d like, probably should be smaller
    // than the maximum possible, for a leisurely change in direction.
    float maxRotation = 5.0f;

    private Vector3 position;
    private Vector3 velocity;
    private float orientation =1;
    private float rotation = 1;


    void Start()
    {
        Debug.LogWarning("WANDER START");
        character = GameObject.Find("Fugitive");
        velocity = new Vector3(rotation, orientation);
        position = new Vector3(1, 1);
        Debug.LogWarning("WANDER START POSITION: " + position.x);
    }

    void Update()
    {
        Debug.LogWarning("WANDER UPDATE");

        update(getSteering(), 20000.0f);
    }

    public void update(Kinematic steeringOutput, float time)
    {
        // Update the position and orientation
        position += velocity * Time.deltaTime;
        orientation += steeringOutput.Rotation * Time.deltaTime;

        // and the velocity and rotation
        velocity = new Vector3(velocity.x + steeringOutput.Linear.x * Time.deltaTime, velocity.y + steeringOutput.Linear.y * Time.deltaTime);
        // velocity += steeringOutput.Linear * time;
        rotation += steeringOutput.Angular * Time.deltaTime;

        character.transform.position = position;
        Debug.LogWarning("WANDER UPDATE POSITION: " + position.x);
        Quaternion newRotation = Quaternion.Euler(0.0f, steeringOutput.Rotation, 0.0f);
        
        character.transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, orientation * Time.deltaTime); 
        character.transform.Translate(position);
        character.transform.Rotate(Vector3.up,1);
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
        result.Rotation = (Random.Range(-150.0f, 150.0f)- Random.Range(-150.0f, 150.0f)) * maxRotation;

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
