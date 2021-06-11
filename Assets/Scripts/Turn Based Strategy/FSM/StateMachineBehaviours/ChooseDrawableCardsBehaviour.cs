using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDrawableCardsBehaviour : StateMachineBehaviour
{
    public delegate void ChooseDrawableCardsEnterDelegate(Animator animator);
    public static ChooseDrawableCardsEnterDelegate OnChooseDrawableCardsEnter;
    public delegate void ChooseDrawableCardsUpdateDelegate(Animator animator);
    public static ChooseDrawableCardsUpdateDelegate OnChooseDrawableCardsUpdate;
    public delegate void ChooseDrawableCardsOnExitDelegate();
    public static ChooseDrawableCardsOnExitDelegate OnChooseDrawableCardsExit;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnChooseDrawableCardsEnter?.Invoke(animator);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnChooseDrawableCardsUpdate?.Invoke(animator);
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnChooseDrawableCardsExit?.Invoke();
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
