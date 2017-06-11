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
        v = new Vector3(0, Random.value, 0);
        i = transform.position;
        Invoke("go", 2);
    }

    void Update()
    {
        if (ready)
            transform.RotateAround(new Vector3(200, 50, 0), v, 0.75f);
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
