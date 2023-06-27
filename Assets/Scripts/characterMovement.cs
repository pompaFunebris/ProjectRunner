using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class characterMovement : MonoBehaviour
{
    private Rigidbody rb;
    //private GameObject gameObject;
    public levelCharacteristics characteristics;
    private float jumpMultiplier;
    private float speed;
    private float songBPM;
    private bool canJump = false;
    public GameObject objectCharacteristics;
    public GameObject musicPlayer;
    public AudioSource aus;
    public int points;
    private float jumpOffset;
    private bool isPLaying = false;

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
        musicPlayer = GameObject.FindGameObjectWithTag("music").gameObject;
        aus = musicPlayer.GetComponent<AudioSource>();
        jumpMultiplier = characteristics.jumpMultiplier;
        speed = characteristics.speed;
        songBPM = characteristics.songBPM;
        jumpOffset = characteristics.jumpOffset;
        Debug.Log("pozz" + transform.position.z);
    }

    // Update is called once per frame
    void Update(){
        
        if(aus.time < 0.1f) { transform.position = new Vector3(41.2f, 0, 3f); }
        Debug.Log("pozz" + transform.position.z);
        transform.position = transform.position + new Vector3(0, 0, speed * Time.deltaTime);
        foreach (Touch touch in Input.touches) {
            //Debug.Log(canJump);
            if (touch.phase == 0) {
                if (transform.position.y < 0.1f) {
                    GetComponent<Animator>().Play("JumpWhileRunning");
                    GameObject[] gos = GameObject.FindGameObjectsWithTag("obstacle");
                    float scoreOffset = Mathf.Infinity;
                    foreach (GameObject go in gos) {
                        if (Math.Abs(scoreOffset) > Math.Abs(go.transform.position.z - jumpOffset - transform.position.z)) scoreOffset = go.transform.position.z - jumpOffset - transform.position.z;
                    }
                    Debug.Log(scoreOffset);

                    //rb.GetComponent<Animator>().Play("JumpWhileRunning");
                    //transform.position = transform.position + new Vector3(0, jumpMultiplier, 0);
                }
            }
        }

    }

}
