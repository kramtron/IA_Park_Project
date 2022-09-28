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
  


    Vector3 newVec;

    private float posAct;
    private float posActTime;
    private bool near = false;
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

            posActTime = Random.Range(5, 20);

            if (posAct > posActTime)
            {
                posAct = 0;
                TargetPositionChanger();

            }
        }

       
    }
    private void TargetPositionChanger()
    {

         target.transform.position = newVec = new Vector3(UnityEngine.Random.Range(20, -20), 0, UnityEngine.Random.Range(20, -20));
    }


   

   

    private void Seek()
    {
        agent.destination=target.transform.position;

    }
}
