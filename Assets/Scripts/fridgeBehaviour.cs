using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using Unity.VisualScripting;

public class fridgeBehaviour : MonoBehaviour
{
    private levelCharacteristics characteristics;
    private bool isDown = false;
    private bool isVisible = false;
    private float songBPM;
    private float speed;
    private float requiredDistanceToFall;
    private float jumpOffset;
    public GameObject objectCharacteristics;
    private float beatTime;
    private bool isFallAnimStarted = false;
    private bool isTipAnimStarted = false;
    private Vector3 initPoz;
    private MeshRenderer[] meshRenderers;
    private float initTime;
    void Start()
    {
        objectCharacteristics = GameObject.FindGameObjectWithTag("characteristics").gameObject;
        characteristics = objectCharacteristics.GetComponent<levelCharacteristics>();
        songBPM = characteristics.songBPM;
        jumpOffset = characteristics.jumpOffset;
        speed = characteristics.speed;
        requiredDistanceToFall = speed/(songBPM / 60.0f); 
        UnityEngine.Debug.Log(requiredDistanceToFall);
        beatTime = 1.0f / (songBPM / 60.0f);
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer meshRenderer in meshRenderers) {
            meshRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        jumpOffset = 0.0f;
        if(Math.Abs(transform.position.z - GameObject.FindWithTag("Player").transform.position.z) < requiredDistanceToFall + jumpOffset + (speed * beatTime)) {
            if(!isTipAnimStarted) {
                isTipAnimStarted = true;
                initTime = Time.time;
                initPoz = transform.position;
            }
            //purc¹ta¿= (Time.time - initTime) / beatTime
            float dist = Math.Abs(transform.position.z - GameObject.FindWithTag("Player").transform.position.z);
            if (!isDown && isTipAnimStarted) transform.RotateAround((transform.position - new Vector3(0, 0, 0)), new Vector3(0, 0, 1), (90/beatTime)*Time.deltaTime);
            if(Time.time - initTime >= beatTime )isDown = true;
        }
        if (Math.Abs(transform.position.z - GameObject.FindWithTag("Player").transform.position.z) < 2.0f*requiredDistanceToFall + jumpOffset + (speed * beatTime)) {
            
            //START ANIM
            if (!isFallAnimStarted) {
                isFallAnimStarted = true;
                initPoz = transform.position;
                foreach (MeshRenderer meshRenderer in meshRenderers) {
                    meshRenderer.enabled = true;
                }
            }
            float dist = Math.Abs(transform.position.z - GameObject.FindWithTag("Player").transform.position.z);
            //STOP ANIM
            if (dist - (2.0f * requiredDistanceToFall + jumpOffset) < 0) {
                isVisible = true;
            }
            //DO THE ANIM
            if (!isVisible) transform.position = initPoz + new Vector3(0, dist - (2.0f * requiredDistanceToFall + jumpOffset), 0);
            
            
            
        }
    }
}
