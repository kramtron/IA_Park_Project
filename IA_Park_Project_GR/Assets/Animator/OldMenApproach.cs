using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OldMenApproach : StateMachineBehaviour
{
    public NavMeshAgent agent;

    public GameObject targetC;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.gameObject.GetComponent<CurrentBench>().TargetBench = BlackBoard.currentTarget;
        targetC = agent.gameObject.GetComponent<CurrentBench>().TargetBench;
        agent = animator.gameObject.GetComponent<NavMeshAgent>();
        agent.destination = targetC.transform.position;

        int amountbench = targetC.GetComponent<amountOldMen>().currentAmount;

        animator.SetInteger("BenchMax", amountbench);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.transform.position.x == targetC.transform.position.x && agent.transform.position.z == targetC.transform.position.z)
        {
            animator.SetBool("inBench", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
