using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 v;
    Vector3 i;
    bool ready = false;

    void Start()
    {
        v = new Vector3(Random.value, Random.value, Random.value);
        i = transform.position;
        Invoke("go", 2);
    }

    void Update()
    {
        if (ready)
            transform.RotateAround(new Vector3(150, 0, 0), v, 0.75f);
        if (ready && transform.position == i)
        {
            ready = false;
            Invoke("go", 2);
        }
    }

    void go()
    {
        ready = true;
    }
}
