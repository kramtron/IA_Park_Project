using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveNavMesh : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;

    public float stopDistance = 5;

    private float freq = 0f;
    public float freqAct;
    
    public float turnAcc = 2;
    public float acc = 5;
    
    public float maxTurnSpeed = 15;
    public float maxSpeed = 20;
    public float minSpeed = 0;
  
    public float angle;
    public float turnSpeed;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (Vector3.Distance(target.transform.position, transform.position) <= stopDistance)
            SlowToTarget();
        else
            MoveToTarget();
    }

    void Seek()
    {
        agent.destination = target.transform.position;
    }
    private void MoveToTarget()
    {
        turnSpeed += turnAcc * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        agent.speed += acc * Time.deltaTime;
        agent.speed = Mathf.Max(agent.speed, maxSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * agent.speed * Time.deltaTime;
        if (agent.speed > maxSpeed)
            agent.speed = maxSpeed;
    }

    private void SlowToTarget()
    {
        turnSpeed += turnAcc * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        agent.speed -= acc / Time.deltaTime;
        agent.speed = Mathf.Max(agent.speed, minSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * agent.speed * Time.deltaTime;
    }
}
