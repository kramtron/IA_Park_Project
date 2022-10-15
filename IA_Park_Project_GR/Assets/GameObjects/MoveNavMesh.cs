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

    private Quaternion rotation;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other is NavMeshAgent)
        {
            agent.angularSpeed += agent.acceleration * Time.deltaTime;
            agent.angularSpeed = Mathf.Min(agent.angularSpeed, agent.angularSpeed*1,5);
            agent.speed += agent.acceleration * Time.deltaTime;
            agent.speed = Mathf.Max(agent.speed, agent.speed*1,5);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * agent.angularSpeed);
            transform.position += transform.forward.normalized * agent.speed * Time.deltaTime;
        }
    }
}
