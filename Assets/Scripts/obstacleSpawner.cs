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
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 59));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 62));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 70));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 78));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 86));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 91));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 94));
        //obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 100));
        //obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 104));
        //obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 108));
        //obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 112));
        //obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 116));
        //obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 120));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 134));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 138));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 142));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 150));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 154));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 157));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 166));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 169));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 174));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 182));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 185));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 189));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 193));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 211));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 214));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 217));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 222));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 227));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 230));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 233));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 238));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 243));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 246));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 250));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 253));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 257));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 261));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 267));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 270));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 280));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 288));
        obstaclePositionsInBeats.Add(new KeyValuePair<string, int>("fridge", 296));
        float distPerBeat = speed * 60.0f / songBPM;
        //Debug.Log("distper"+distPerBeat);
        foreach(KeyValuePair<string, int> obstacle in obstaclePositionsInBeats) {
            switch(obstacle.Key) {
                case "fridge":
                    GameObject tree = Instantiate(obstacleFridge);
                    tree.transform.position = new Vector3(43f, 0f, (obstacle.Value * distPerBeat) + jumpOffset);
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
