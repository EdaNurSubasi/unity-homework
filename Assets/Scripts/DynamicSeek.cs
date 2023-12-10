using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSeek: MonoBehaviour
{
    public GameObject character;
    public GameObject target;
    public float maxSpeed;

    private Vector3 position;
    private Vector3 velocity;
    private float orientation = 1;
    private float rotation = 1;

    void Start()
    {
        character = GameObject.Find("Follower");
        target = GameObject.Find("Fugitive");

        //Instantiate(markerPrefab, character.transform.position, Quaternion.identity);
        velocity = new Vector3(rotation, orientation);
        position = new Vector3(1, 1);
    }

    void Update()
    {
        //Debug.LogWarning("DYNAMIC UPDATE");
        Kinematic kinematic = getSteering();

        // Update the position and orientation
        position += maxSpeed * Time.deltaTime * velocity.normalized;
        orientation += kinematic.Rotation * Time.deltaTime;
        velocity = new Vector3(velocity.x + kinematic.Linear.x * Time.deltaTime, velocity.y + kinematic.Linear.y * Time.deltaTime);
        character.transform.position = new Vector3(maxSpeed * Time.deltaTime * kinematic.Velocity.x * target.transform.position.x, maxSpeed * Time.deltaTime * kinematic.Velocity.y * target.transform.position.y);
        // character.transform.Translate(direction * maxSpeed * (Time.deltaTime / 2));
        // character.transform.Translate(new Vector3(maxSpeed * Time.deltaTime * kinematic.Velocity.x * target.transform.position.x, maxSpeed * Time.deltaTime * kinematic.Velocity.y * target.transform.position.y));
        character.transform.Translate(position);
        character.transform.Rotate(Vector3.up,kinematic.Rotation);

        //Instantiate(markerPrefab, character.transform.position, Quaternion.identity);
    }

    Kinematic getSteering()
    {

        Kinematic result=new();
        //Get the direction to the target
        result.Velocity = new Vector3(character.transform.position.x + target.transform.position.x - character.transform.position.x, character.transform.position.y + target.transform.position.y - character.transform.position.y);

        Debug.LogWarning("DYNAMIC UPDATE VELOCITY: "+result.Velocity.x);

        // The velocity is along this direction
        //result.Velocity.Normalize();
        result.Velocity *= maxSpeed;

        // Face the direction we want to move
        //character.transform.rotation = newOrientation(character.transform.rotation, result.Velocity);
        result.Rotation = (target.transform.rotation.x*Time.deltaTime);
       // result.Rotation = 0;
        return result;
    }

    public GameObject Character { get => character; set => character = value; }
    public GameObject Target { get => target; set => target = value; }
}
