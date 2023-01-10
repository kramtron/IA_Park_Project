using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;
    public Vector3 pos;
    public Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = target.transform.rotation;
        transform.position = target.transform.TransformPoint(pos);
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.TransformPoint(pos);

    }
}
