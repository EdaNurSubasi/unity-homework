using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSeek: MonoBehaviour
{
    public GameObject character;
    public GameObject target;

    void Start()
    {
        //Debug.LogWarning("DYNAMIC START");
    }

    void Update()
    {
        //Debug.LogWarning("DYNAMIC UPDATE");
    }

    public GameObject Character { get => character; set => character = value; }
    public GameObject Target { get => target; set => target = value; }
}
