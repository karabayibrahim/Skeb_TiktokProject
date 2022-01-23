using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using System;
public class Cameraman : Human
{
    private int _targetGateIndex = 0;
    private Transform Target;

    public NavMeshAgent Agent;
    public bool XMoveControl = false;
    public static Action XMoveAction;

    // Start is called before the first frame update

    public int TargetGateIndex
    {
        get
        {
            return _targetGateIndex;
        }
        set
        {
            if (TargetGateIndex == value)
            {
                return;
            }
            _targetGateIndex = value;
        }
    }

    void Start()
    {
        base.AssigmentComponent();
        PlayerController.WalkActon += CameramanMove;
        PlayerController.IdleAction += IdleOverride;
        XMoveAction += XMove;
        GameManager.Instance.YoyoFonk(10,gameObject);
    }

    private void OnDisable()
    {
        PlayerController.WalkActon -= CameramanMove;
        PlayerController.IdleAction -= IdleOverride;
        XMoveAction -= XMove;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(GameManager.Instance.CurrentLevel.PlayerController.gameObject.transform);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.GetComponent<ICollectable>()!=null)
    //    {
    //        other.gameObject.GetComponent<ICollectable>().DoCollectCameraman();
    //    }
    //}

    public override void AnimPositon()
    {
        switch (HumanState)
        {
            case HumanState.IDLE:
                break;
            case HumanState.WALK:
                break;
            default:
                break;
        }
    }

    private void CameramanMove()
    {
        WalkStatus();
    }

    private void IdleOverride()
    {
        IdleStatus();
    }

    private void XMove()
    {
        XMoveControl = true;
    }

}
