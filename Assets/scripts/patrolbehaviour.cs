using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrolbehaviour : StateMachineBehaviour
{
    float timer;
    List<Transform> waypoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    float ChaseRange = 15f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       timer = 0; 
       Transform waypointsobject = GameObject.FindWithTag("waypoints").transform;
       foreach (Transform t in waypointsobject)
            waypoints.Add(t);

            agent = animator.GetComponent<NavMeshAgent>();
            agent.SetDestination(waypoints[0].position);
            player = GameObject.FindWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if(agent.remainingDistance <= agent.stoppingDistance)
        {
        agent.SetDestination(waypoints[Random.Range(0,waypoints.Count)].position);
        }
       timer += Time.deltaTime;
       if(timer > 10)
          animator.SetBool("ispatrolling",false);
          float distance = Vector3.Distance(animator.transform.position, player.position);
         if(distance < ChaseRange)
         {
            animator.SetBool("ischasing",true);
         }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent.SetDestination(agent.transform.position);
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
