using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class fridgeBehaviour : MonoBehaviour
{
    private levelCharacteristics characteristics;
    private bool isDown = false;
    private bool isVisible = false;
    private float songBPM;
    private float requiredDistanceToFall;
    private float jumpOffset;
    public GameObject objectCharacteristics;

    void Start()
    {
        objectCharacteristics = GameObject.FindGameObjectWithTag("characteristics").gameObject;
        characteristics = objectCharacteristics.GetComponent<levelCharacteristics>();
        songBPM = characteristics.songBPM;
        jumpOffset = characteristics.jumpOffset;
        requiredDistanceToFall = 15.0f/(songBPM / 60.0f); //15 na speed z characterMovement
        UnityEngine.Debug.Log(requiredDistanceToFall);
    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.Log(Math.Abs(transform.position.z - GameObject.FindWithTag("Player").transform.position.z));
        if(Math.Abs(transform.position.z - GameObject.FindWithTag("Player").transform.position.z) < requiredDistanceToFall + jumpOffset) {
            float dist = Math.Abs(transform.position.z - GameObject.FindWithTag("Player").transform.position.z);
            //UnityEngine.Debug.Log("dist=" + dist.ToString());
            if (!isDown) transform.RotateAround((transform.position - new Vector3(0, 0, 0)), new Vector3(0, 0, 1), 90);
            isDown = true;
        }
        if (Math.Abs(transform.position.z - GameObject.FindWithTag("Player").transform.position.z) < 2.0f*requiredDistanceToFall + jumpOffset) {
            //if (!isVisible) transform.position = transform.position + new Vector3(0, 6.5F, 0);
            //gameObject.SetActive(true);
            float dist = Math.Abs(transform.position.z - GameObject.FindWithTag("Player").transform.position.z);
            //UnityEngine.Debug.Log("distvis=" + dist.ToString());
            if (!isVisible) transform.position = transform.position + new Vector3(0, -3.0f, 0);
            isVisible = true;
            //UnityEngine.Debug.Log("should be visible");
        }
    }
}
