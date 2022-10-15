using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarScript : MonoBehaviour
{
    [SerializeField] GameObject target1;
    [SerializeField] GameObject target2;
    [SerializeField] GameObject target3;
    [SerializeField] GameObject target4;
    [SerializeField] GameObject target5;
    [SerializeField] GameObject target6;

    NavMeshAgent agent;


    private int num_targets = 6;

    private float freq = 0f;
    public float freqAct;


    private GameObject[] targetArray;


    private GameObject actualTarget;
    Vector3 newVec;

    private float posAct;
    private float posActTime;
    private bool near = false;
    private float stopDistance = 3;

    private int targetNum = 0;
    private bool turning = false;
    // Start is called before the first frame update
    void Start()
    {
        targetArray = new GameObject[num_targets];

        targetArray[0] = target1;
        targetArray[1] = target2;
        targetArray[2] = target3;
        targetArray[3] = target4;
        targetArray[4] = target5;
        targetArray[5] = target6;

        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        int random = UnityEngine.Random.Range(0, 2);

        if (near)
        {
            if (targetNum >= 5)
            {
                targetNum = 0;
            }
            else
            {

                if (targetNum == 2 && random == 1 && !turning)
                {
                    targetNum = 5;
                    turning = true;
                }
                else if (targetNum == 5 && UnityEngine.Random.Range(0, 1) == 1 && !turning) 
                {
                    targetNum = 2;
                    turning = true;

                }
                else
                {
                    //if(turning)
                    targetNum += 1;
                    turning = false;

                }

            }
        }

        actualTarget = targetArray[targetNum];

        freq += Time.deltaTime;
        if (freq > freqAct)
        {
            freq -= freqAct;
            Seek();

        }

        if (Vector3.Distance(actualTarget.transform.position, transform.position) <= stopDistance)
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
