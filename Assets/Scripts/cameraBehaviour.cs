using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour {

    [SerializeField] private float distanceFromPlayer = 6;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(0, 5.0f, -distanceFromPlayer);
    }
}
