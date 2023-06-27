using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpMultiplier = 1;
    [SerializeField] public float speed = 15;
    [SerializeField] private int songBPM = 160;
    private bool canJump = false;

    private void OnCollisionEnter(Collision collision) {
        canJump = true;
    }
    private void OnCollisionExit(Collision collision) {
        canJump = false;
    }

    void Start()
    {
        Debug.Log(canJump);
    }

    // Update is called once per frame
    void Update(){
        transform.position = transform.position + new Vector3(0, 0, speed * Time.deltaTime);
        foreach (Touch touch in Input.touches) {
            //Debug.Log(canJump);
            if (touch.phase == 0) {
                if (canJump) {
                    transform.position = transform.position + new Vector3(0, jumpMultiplier, 0);
                }
            }
        }

    }

}
