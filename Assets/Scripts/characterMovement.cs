using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    private Rigidbody rb;
    public levelCharacteristics characteristics;
    private float jumpMultiplier;
    private float speed;
    private float songBPM;
    private bool canJump = false;
    public GameObject objectCharacteristics;

    private void OnCollisionEnter(Collision collision) {
        canJump = true;
    }
    private void OnCollisionExit(Collision collision) {
        canJump = false;
    }

    void Start()
    {
        objectCharacteristics = GameObject.FindGameObjectWithTag("characteristics").gameObject;
        characteristics = objectCharacteristics.GetComponent<levelCharacteristics>();
        jumpMultiplier = characteristics.jumpMultiplier;
        speed = characteristics.speed;
        songBPM = characteristics.songBPM;
    }

    // Update is called once per frame
    void Update(){
        transform.position = transform.position + new Vector3(0, 0, speed * Time.deltaTime);
        foreach (Touch touch in Input.touches) {
            //Debug.Log(canJump);
            if (touch.phase == 0) {
                if (transform.position.y < 0.1f) {
                    transform.position = transform.position + new Vector3(0, jumpMultiplier, 0);
                }
            }
        }

    }

}
