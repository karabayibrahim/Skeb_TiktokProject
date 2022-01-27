using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class JumpOn : StateMachineBehaviour
{

    private void FinishStatus()
    {
        Destroy(this);
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Finish.FinishAction += FinishStatus;
        animator.gameObject.GetComponent<Human>().IdleBlock = true;
        animator.gameObject.GetComponent<Human>().WalkBlock = true;
        //GameManager.Instance.CurrentLevel.PlayerController.Cameraman.DOLocalMoveZ(GameManager.Instance.CurrentLevel.PlayerController.Cameraman.position.z + 0.1f, 0.5f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponentInParent<PlayerController>()!=null)
        {
            GameManager.Instance.CurrentLevel.PlayerController.VerticalMove();

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    Destroy(GameManager.Instance.CurrentLevel.PlayerController);
    //}

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
