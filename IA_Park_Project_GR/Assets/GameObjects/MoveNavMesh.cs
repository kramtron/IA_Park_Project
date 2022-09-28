using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveNavMesh : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    
    private float freq = 0f;
    public float freqAct;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        freq += Time.deltaTime;
        if (freq > freqAct)
        {
            freq -= freqAct;
            Seek();

        }
    }

    void Seek()
    {
        agent.destination = target.transform.position;
    }
}
