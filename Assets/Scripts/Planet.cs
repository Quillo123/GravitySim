using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{


    public Vector3 velocity = Vector3.zero;
    public Vector3 force = Vector3.zero;
    public float mass = 1;
    public float size = 10;
    public bool isStatic = false;

    GameController GC => GameController.GC;

    private void Start()
    {
        transform.localScale = Vector3.one * size;
    }
    public void SimulateNextStep(float fixedDeltaTime)
    {
        velocity += (force / mass) * fixedDeltaTime;
        force = Vector3.zero;
        if (!isStatic)
        {
            transform.position += velocity * fixedDeltaTime;
        }
    }    
}
