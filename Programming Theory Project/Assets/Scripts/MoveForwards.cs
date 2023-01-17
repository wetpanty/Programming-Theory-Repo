using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwards : Vehicle
{


    protected override void Start()
    {
        base.Start();
        speed = 30;
    }
    protected override void FixedUpdate()
    {
        Moveforwards();
    }

    void Moveforwards()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
}
