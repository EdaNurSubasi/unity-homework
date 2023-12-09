using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FugitiveController : MonoBehaviour
{
    
    public Transform target;
    private float maxPrediction = 2.0f;
    private DynamicSeek seek;

    void Start() {
        target = gameObject.AddComponent<FollowerController>().transform;
        seek = GetComponent<DynamicSeek>(); 
    }
   
    void Update()
    {
        
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;
        System.Console.WriteLine("**********************");
       // float speed = seek.Velocity.magnitude;
        float prediction = 0.0f;
        //if (maxPrediction <= distance / speed) prediction = maxPrediction;
       // else prediction = distance / speed;
        seek.Target.transform.position = target.position + (target.GetComponent<KinematicWanderer>().Velocity * prediction);
    }
}
