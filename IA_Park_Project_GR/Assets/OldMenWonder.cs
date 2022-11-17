using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OldMenWonder : StateMachineBehaviour
{
    public NavMeshAgent agent;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject currentTarget;

    private float freq = 0f;
    public float freqAct;
    float MinTimeWonder = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.gameObject.GetComponent<NavMeshAgent>();
        animator.SetBool("Bench", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        freq += Time.deltaTime;

        if (freq > freqAct)
        {
            freq -= freqAct;
            Vector3 wanderTarget = Vector3.zero;

            wanderTarget += new Vector3(Random.Range(-22.0f, 20.0f), 2, Random.Range(-50.0f, -10.0f));
            
            agent.destination = wanderTarget;
        }

        if((Vector3.Distance(agent.transform.position, target1.transform.position) < 5f) && animator.GetFloat("MinWonder") > 50f)
        {
            Debug.Log("Find1");
            BlackBoard.currentTarget = target1;
            animator.SetBool("Bench", true);
        }
        else if ((Vector3.Distance(agent.transform.position, target2.transform.position) < 5f) && animator.GetFloat("MinWonder") > 50f)
        {
            BlackBoard.currentTarget = target2;
            Debug.Log("Find2");
            animator.SetBool("Bench", true);
        }
        else if ((Vector3.Distance(agent.transform.position, target3.transform.position) < 5f) && animator.GetFloat("MinWonder") > 50f)
        {
            BlackBoard.currentTarget = target3;
            Debug.Log("Find3");
            animator.SetBool("Bench", true);
        }

        MinTimeWonder = animator.GetFloat("MinWonder");
        MinTimeWonder += 0.1f;
        animator.SetFloat("MinWonder", MinTimeWonder);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("MinWonder", 0);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
