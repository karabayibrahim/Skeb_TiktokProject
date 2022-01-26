using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HugWalk : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.HUGWALK;
        GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.HUGWALK;
        //GameManager.Instance.CurrentLevel.PlayerController.Female.transform.DOLocalMove(new Vector3(1.7f, 0.78f, 0.76f), 0.01f);
        //GameManager.Instance.CurrentLevel.PlayerController.Female.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.001f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.GetComponentInParent<PlayerController>()!=null)
        {
            animator.SetLayerWeight(1, 0);
            GameManager.Instance.CurrentLevel.PlayerController.Female.transform.DOLocalMove(new Vector3(1.5f, 0.78f, 6.2f), 0.01f);
            //GameManager.Instance.CurrentLevel.PlayerController.Female.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.0001f);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
            GameManager.Instance.CurrentLevel.VideoPlayerController.Female.transform.DOLocalMove(new Vector3(1.5f, 0.78f, 6.2f), 0.01f);
            //GameManager.Instance.CurrentLevel.VideoPlayerController.Female.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.0001f);
        }
        
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
