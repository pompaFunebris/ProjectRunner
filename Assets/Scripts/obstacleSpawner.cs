using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.TerrainTools;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    private levelCharacteristics characteristics;
    [SerializeField] private GameObject obstacleFridge;
    private List<KeyValuePair<string, int>> obstaclePositionsInBeats = new List<KeyValuePair<string, int>>();
    private float speed; // zrobiæ var
    public float songBPM; //tez na var
    public GameObject objectCharacteristics;
    private float jumpOffset;
    // Start is called before the first frame update
    void Start()
    {
        objectCharacteristics = GameObject.FindGameObjectWithTag("characteristics").gameObject;
        characteristics = objectCharacteristics.GetComponent<levelCharacteristics>();
        speed = characteristics.speed;
        songBPM = characteristics.songBPM;
        jumpOffset = characteristics.jumpOffset;
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 38));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 46));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 54));
        float distPerBeat = speed * 60.0f / songBPM;
        Debug.Log("distper"+distPerBeat);
        foreach(KeyValuePair<string, int> obstacle in obstaclePositionsInBeats) {
            switch(obstacle.Key) {
                case "fridge":
                    GameObject tree = Instantiate(obstacleFridge);
                    tree.transform.position = new Vector3(43f, 3f, (obstacle.Value * distPerBeat) + jumpOffset);
                    //Debug.Log("instantiated tree at" + obstacle.Value * distPerBeat);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
