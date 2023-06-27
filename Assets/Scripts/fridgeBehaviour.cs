using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class fridgeBehaviour : MonoBehaviour
{
    
    private bool isDown = false;
    private bool isVisible = false;
    [SerializeField] private int songBPM = 160;
    private float requiredDistanceToFall;
    [SerializeField] private float jumpOffset = 1;
    
    void Start()
    {
        requiredDistanceToFall = 15/(songBPM / 60); //15 na speed z characterMovement
        UnityEngine.Debug.Log(requiredDistanceToFall);
    }

    // Update is called once per frame
    void Update()
    {
        if(Math.Abs(transform.position.z - GameObject.FindWithTag("Player").transform.position.z) < requiredDistanceToFall + jumpOffset) {
            if (!isDown) transform.RotateAround((transform.position - new Vector3(0, 0, 0)), new Vector3(0, 0, 1), 90);
            isDown = true;
        }
        if (Math.Abs(transform.position.z - GameObject.FindWithTag("Player").transform.position.z) < 2*requiredDistanceToFall) {
            if (!isVisible) transform.position = transform.position + new Vector3(0, 6.5F, 0);
            isVisible = true;
        }
    }
}
