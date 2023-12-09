using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerController : MonoBehaviour
{
    private ArrayList targets;
    private int currentid = 0;
    private DynamicSeek seek;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }



    /*
    private DynamicAlign align;

    // Start is called before the first frame update
    void Start()
    {
        align = this.GetComponent<DynamicAlign>();

        seek = GetComponent<DynamicSeek>();
        targets = new ArrayList();
        targets.Add(new Fugitive());
        targets.Add(new Vector3(-10, 0, 10)); targets.Add(new Vector3(-10, 0, 0));
        targets.Add(new Vector3(0, 0, 0));
        for (int i = 0; i < targets.Count; i++)
        {
            Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube),
            (Vector3)targets[i], Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = transform.position - (Vector3)targets[currentid];

        if (distance.magnitude < 0.5)
        {

            currentid = (currentid + 1) % targets.Count;
        }

        seek.target = (Vector3)targets[currentid];
        align.target = Mathf.Atan2(seek.velocity.x, seek.velocity.z) * Mathf.Rad2Deg;
    }

    public DynamicAlign Align { get => align; set => align = value; }
    public DynamicSeek Seek { get => seek; set => seek = value; }
    public ArrayList Targets { get => targets; set => targets = value; }
    public int Currentid { get => currentid; set => currentid = value; }
    */
}
