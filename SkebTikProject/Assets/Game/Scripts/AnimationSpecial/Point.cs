using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Point : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.GetComponentInParent<PlayerController>() != null)
        {
            if (animator.gameObject.tag=="Female")
            {
                var Female = GameManager.Instance.CurrentLevel.PlayerController.Female;
                Female.transform.DOLocalMove(new Vector3(-1.5f, 0, 0f), 0.5f);
                Female.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                Female.HumanState = HumanState.WALK;
            }
            else
            {
                var Male = GameManager.Instance.CurrentLevel.PlayerController.Male;
                Male.transform.DOLocalMove(new Vector3(1.5f, 0, 0f), 0.5f);
                Male.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                Male.HumanState = HumanState.WALK;
            }
            
            //GameManager.Instance.CurrentLevel.PlayerController.Female.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.0001f);
        }
        else
        {
            
            if (animator.gameObject.tag == "Female")
            {
                var Female = GameManager.Instance.CurrentLevel.VideoPlayerController.Female;
                Female.transform.DOLocalMove(new Vector3(-1.5f, 0, 0f), 0.5f);
                Female.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                Female.HumanState = HumanState.WALK;
            }
            else
            {
                var Male = GameManager.Instance.CurrentLevel.VideoPlayerController.Male;
                Male.transform.DOLocalMove(new Vector3(1.5f, 0, 0f), 0.5f);
                Male.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                Male.HumanState = HumanState.WALK;
            }
            //GameManager.Instance.CurrentLevel.VideoPlayerController.Female.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.0001f);
        }

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
