using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OldMenRest : StateMachineBehaviour
{
    int BenchCurrent = 0;
    float timeRest = 0;

    public NavMeshAgent agent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BenchCurrent = animator.GetInteger("BenchMax");
        BenchCurrent++;
        animator.SetInteger("BenchMax", BenchCurrent);

        agent.gameObject.GetComponent<CurrentBench>().TargetBench.GetComponent<amountOldMen>().currentAmount = animator.GetInteger("BenchMax");

        agent = animator.gameObject.GetComponent<NavMeshAgent>();

        agent.destination = agent.gameObject.GetComponent<CurrentBench>().TargetBench.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeRest = animator.GetFloat("restTime");
        timeRest += 0.1f;
        animator.SetFloat("restTime", timeRest);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BenchCurrent = animator.GetInteger("BenchMax");
        BenchCurrent--;
        animator.SetInteger("BenchMax", BenchCurrent);

        agent.gameObject.GetComponent<CurrentBench>().TargetBench.GetComponent<amountOldMen>().currentAmount = animator.GetInteger("BenchMax");

        animator.SetFloat("restTime", 0);
        animator.SetBool("inBench", false);
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
