using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunnerScript : MonoBehaviour
{
    [SerializeField] GameObject target1;
    [SerializeField] GameObject target2;
    [SerializeField] GameObject target3;
    [SerializeField] GameObject target4;

    private GameObject[] targetArray;

    private GameObject actualTarget;

    NavMeshAgent agent;

    private int num_targets = 4;

    private int targetNum = 0;

    private float freq = 0f;
    public float freqAct;

    private float posAct;
    private float posActTime;

    private bool near = false;

    Vector3 newVec;

    // Start is called before the first frame update
    void Start()
    {
        targetArray = new GameObject[num_targets];
        
            targetArray[0] = target1;
            targetArray[1] = target2;
            targetArray[2] = target3;
            targetArray[3] = target4;
        
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (near)
        {
            if (targetNum == 3)
            {
                targetNum = 0;
            }
            else
            targetNum += 1;
        }

        actualTarget = targetArray[targetNum];

        freq += Time.deltaTime;
        if (freq > freqAct)
        {
            freq -= freqAct;
            Seek();
        }

        if (Vector3.Distance( transform.position, actualTarget.transform.position) <= agent.stoppingDistance)
        {
            near = true;
        }
        else
            near = false;
    }
  
  private void Seek()
    {
        agent.destination = actualTarget.transform.position;
    }
}
