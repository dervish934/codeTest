﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody RocketRB;
    public float upspeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        RocketRB = GetComponent<Rigidbody>(); 
        
    }

    // Update is called once per frame
    void Update()
    {

        ProcessInput();
        
    }

     void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
             RocketRB.AddRelativeForce(transform.up * upspeed);
            //RocketRB.AddForce(transform.up * upspeed);
            print("Thrusting");
        }

        if (Input.GetKey(KeyCode.A))
        {
            print("Rotating Lef");
        }else if (Input.GetKey(KeyCode.D))
        {
            print("Rotating Right");

        }

    }
} 
 