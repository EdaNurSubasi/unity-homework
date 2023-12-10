using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoint : MonoBehaviour
{
    public GameObject character;
    public GameObject markerPrefab;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(markerPrefab, character.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        count++;

        if (count % 10 == 0)
        {

        Instantiate(markerPrefab, character.transform.position, Quaternion.identity);
        }
    }
}
