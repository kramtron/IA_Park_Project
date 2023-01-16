using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChillingBoyScript : MonoBehaviour
{
    [SerializeField] GameObject target;

    NavMeshAgent agent;

    private float freq = 0f;
    public float freqAct;
  
    private float posAct;
    private float posActTime;
    private float stopDistance = 3;

    private bool near = false;

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
     
        if (near)
        {
            posAct += Time.deltaTime;
            posActTime = Random.Range(5, 10);

            if (posAct > posActTime)
            {
                posAct = 0;
                TargetPositionChanger();
            }
        }

        if (Vector3.Distance(target.transform.position, transform.position) <= stopDistance)
        {
            near = true;
        }
        else
            near = false;
    }

    private void TargetPositionChanger()
    {
        target.transform.position = newVec = new Vector3(UnityEngine.Random.Range(10, -10), 0, UnityEngine.Random.Range(10, -10));
    }

    private void Seek()
    {
        agent.destination=target.transform.position;
    }
}
