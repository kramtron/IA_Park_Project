using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DynamicScript : MonoBehaviour
{
    [SerializeField] GameObject target;

    NavMeshAgent agent;

    private float freq = 0f;
    public float freqAct;

    private float posAct;
    private float posActTime;

    Vector3 newVec;
    
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
 
    private void Seek()
    {
        agent.destination = target.transform.position;
    }
}
