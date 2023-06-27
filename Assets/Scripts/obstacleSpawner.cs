using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.TerrainTools;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacleFridge;
    private List<KeyValuePair<string, int>> obstaclePositionsInBeats = new List<KeyValuePair<string, int>>();
    private int speed = 15; // zrobiæ var
    private int bpm = 160; //tez na var
    // Start is called before the first frame update
    void Start()
    {
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 3));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 4));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 5));
        float distPerBeat = speed * 60 / bpm;
        foreach(KeyValuePair<string, int> obstacle in obstaclePositionsInBeats) {
            switch(obstacle.Key) {
                case "fridge":
                    GameObject tree = Instantiate(obstacleFridge);
                    tree.transform.position = new Vector3(2f, 0f, obstacle.Value * distPerBeat);
                    Debug.Log("instantiated tree at" + obstacle.Value * distPerBeat);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
