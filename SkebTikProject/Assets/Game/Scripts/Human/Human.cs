using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Human : MonoBehaviour
{
    private HumanState _humanState;

    public Animator Anim;

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
            default:
                break;
        }
    }

    void Start()
    {
        
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
}
