using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Human : MonoBehaviour
{
    private HumanState _humanState;
    private HumanState _tempState;
    public Animator Anim;


    public abstract void AnimPositon();
    public HumanState HumanState
    {
        get
        {
            return _humanState;
        }
        set
        {
            if (HumanState==value)
            {
                return;
            }
            _humanState = value;
            OnStateChanged();
            AnimPositon();
        }
    }

    private void OnStateChanged()
    {
        switch (HumanState)
        {
            case HumanState.IDLE:
                RunAnimation("Idle");
                break;
            case HumanState.WALK:
                RunAnimation("Walk");
                break;
            case HumanState.GETAHEAD:
                _tempState = HumanState.GETAHEAD;
                RunAnimation("GetAhead");
                break;
            case HumanState.TAKEOFF:
                RunAnimation("TakeOff");
                break;
            case HumanState.DRESSUP:
                RunAnimation("DressUp");
                break;
            case HumanState.HUGHER:
                _tempState = HumanState.HUGHER;
                RunAnimation("HugHer");
                break;
            case HumanState.SLAPYOUR:
                RunAnimation("SlapYour");
                break;
            default:
                break;
        }
    }

    void Start()
    {
        
    }
    private void OnEnable()
    {
        PlayerController.WalkActon += WalkStatus;
        PlayerController.IdleAction += IdleStatus;
    }


    private void OnDisable()
    {
        PlayerController.WalkActon -= WalkStatus;
        PlayerController.IdleAction -= IdleStatus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RunAnimation(string _animName)
    {
        Anim.CrossFade(_animName, 0.01f);
    }
    internal void AssigmentComponent()
    {
        Anim = GetComponent<Animator>();
    }
    internal void WalkStatus()
    {
        switch (HumanState)
        {
            case HumanState.IDLE:
                TempStateControl();
                break;
            case HumanState.WALK:
                HumanState = HumanState.WALK;
                break;
            case HumanState.GETAHEAD:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.TAKEOFF:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.HUGHER:
                if (gameObject.tag=="Male")
                {
                    HumanState = HumanState.GETAHEAD;
                }
                break;
            case HumanState.SLAPYOUR:
                TempStateControl();
                break;
            case HumanState.DRESSUP:
                HumanState = HumanState.GETAHEAD;
                break;
            default:
                break;
        }
        
    }
    internal void IdleStatus()
    {
        switch (HumanState)
        {
            case HumanState.IDLE:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.WALK:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.GETAHEAD:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.SLAPYOUR:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.TAKEOFF:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.HUGHER:
                if (gameObject.tag=="Male")
                {
                    HumanState = HumanState.IDLE;
                }
                TempStateControl();
                break;
            case HumanState.DRESSUP:
                HumanState = HumanState.IDLE;
                break;
            default:
                HumanState = HumanState.IDLE;
                break;
        }
        //HumanState = HumanState.IDLE;
    }

    private void TempStateControl()
    {
        switch (_tempState)
        {
            case HumanState.IDLE:
                HumanState = HumanState.WALK;
                break;
            case HumanState.WALK:
                break;
            case HumanState.GETAHEAD:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.SLAPYOUR:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.TAKEOFF:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.HUGHER:
                HumanState = HumanState.HUGHER;
                break;
            case HumanState.DRESSUP:
                HumanState = HumanState.GETAHEAD;
                break;
            default:
                break;
        }
    }
}
