using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloackManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject[] allFish;
    public int numFish = 69;

    public Vector3 Limits;

    public bool Bounded = true;
    public bool Randomize = false;
    public bool FollowLid = false;

    public GameObject Lider;


    [Header("\n\nFish Settings")]
    [Range(0.0f, 5.0f)]
    public float MinSpeed;

    [Range(0.0f, 5.0f)]
    public float MaxSpeed;

    [Range(0.0f, 10.0f)]
    public float NeighbourDistance;

    [Range(0.0f, 5.0f)]
    public float RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        allFish = new GameObject[numFish];
        for (int i = 0; i < numFish; ++i)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            //Vector3 randomize = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
            Vector3 randomize = new Vector3(0,1,0);
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.LookRotation(randomize));
            allFish[i].GetComponent<Flock>().myManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
