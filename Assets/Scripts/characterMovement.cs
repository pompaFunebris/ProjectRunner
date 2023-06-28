using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    private float score = 0;

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
        scoreText.text = "";
    }

    // Update is called once per frame
    void Update(){
        if(transform.position.z >1700) {
            PlayerPrefs.SetInt("MuseumInvasion", (int)score);
            SceneManager.LoadScene("Menu");
        }
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
                    if (Math.Abs(scoreOffset) < 0.5f) {
                        score += 100;
                        scoreText.text = "Perfect!";
                    } else if (Math.Abs(scoreOffset) < 1.5f) {
                        score += 50;
                        scoreText.text = "Great!";
                    } else if (Math.Abs(scoreOffset) < 3f) {
                        score += 25;
                        scoreText.text = "Good!";
                    } else {
                        scoreText.text = "Miss!";
                    }
                    //rb.GetComponent<Animator>().Play("JumpWhileRunning");
                    //transform.position = transform.position + new Vector3(0, jumpMultiplier, 0);
                }
            }
        }

    }

}
