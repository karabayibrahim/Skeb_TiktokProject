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
            if (GameManager.Instance.CurrentLevel.PlayerController.Male != null && GameManager.Instance.CurrentLevel.PlayerController.Female != null)
            {
                OnStateChanged();
            }
            if (GameManager.Instance.CurrentLevel.PlayerController.Male!=null&& GameManager.Instance.CurrentLevel.PlayerController.Female != null)
            {
                AnimPositon();
            }
        }
    }

    private void OnStateChanged()
    {
        switch (HumanState)
        {
            case HumanState.IDLE:
                RunAnimation("Idle");
                var Cameraman = GameManager.Instance.CurrentLevel.PlayerController.Cameraman;
                if (Cameraman!=null)
                {
                    if (Cameraman.gameObject.tag == "Cameraman")
                    {
                        if (Cameraman.gameObject.GetComponent<Cameraman>().YoyoBool)
                        {
                            RunAnimation("IdleLegRight");
                        }
                        else
                        {
                            RunAnimation("IdleLeg");
                        }
                        Cameraman.gameObject.GetComponent<Cameraman>().MySpine.transform.DOLocalRotate(new Vector3(0, 90f, 0), 0.001f);
                    }
                }
                
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
                RunAnimation("GetAhead");
                break;
            case HumanState.DRESSUP:
                _tempState = HumanState.DRESSUP;
                RunAnimation("DressUp");
                RunAnimation("GetAhead");
                break;
            case HumanState.HUGHER:
                _tempState = HumanState.HUGHER;
                RunAnimation("HugHer");
                break;
            case HumanState.SLAPYOUR:
                _tempState = HumanState.SLAPYOUR;
                RunAnimation("SlapYour");
                RunAnimation("GetAhead");
                break;
            case HumanState.WALKKEEP:
                _tempState = HumanState.WALKKEEP;
                RunAnimation("Walk");
                break;
            case HumanState.START:
                _tempState = HumanState.START;
                RunAnimation("Start");
                break;
            case HumanState.HUGWALK:
                _tempState = HumanState.HUGWALK;
                RunAnimation("HugWalk");
                break;
            case HumanState.POINTBOY:
                _tempState = HumanState.POINTBOY;
                RunAnimation("PointBoy");
                RunAnimation("Walk");
                break;
            case HumanState.POINTGIRL:
                _tempState = HumanState.POINTGIRL;
                RunAnimation("PointGirl");
                RunAnimation("Walk");
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
        HumanState = HumanState.START;
    }


    private void OnDisable()
    {
        //PlayerController.WalkActon -= WalkStatus;
        //PlayerController.IdleAction -= IdleStatus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RunAnimation(string _animName)
    {
        if (Anim!=null)
        {
            Anim.CrossFade(_animName, 0.001f);
        }
    }
    //private void RunAnimationDelay(string _animName)
    //{
    //    Anim.CrossFade(_animName, 2f);
    //}
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
                TempStateControl();
                break;
            case HumanState.WALKKEEP:
                HumanState = HumanState.WALK;
                break;
            case HumanState.GETAHEAD:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.TAKEOFF:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.HUGHER:
                //var Male = GameManager.Instance.CurrentLevel.PlayerController.MaleObj;
                //if (Male!=null)
                //{
                //    if (Male.tag == "Male")
                //    {
                //    }

                //}
                GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.SLAPYOUR:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.DRESSUP:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.POINTBOY:
                //TempStateControl();
                HumanState = HumanState.POINTBOY;
                break;
            case HumanState.POINTGIRL:
                //TempStateControl();
                HumanState = HumanState.POINTGIRL;
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
                //TempStateControl();
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
                //var Male = GameManager.Instance.CurrentLevel.PlayerController.MaleObj;
                //if (Male != null)
                //{
                //    if (Male.tag == "Male")
                //    {
                //        HumanState = HumanState.IDLE;
                //    }

                //}
                GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.IDLE;
                TempStateControl();
                break;
            case HumanState.DRESSUP:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.POINTBOY:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.POINTGIRL:
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
                HumanState = HumanState.GETAHEAD;
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
                //HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.DRESSUP:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.WALKKEEP:
                //HumanState = HumanState.GETAHEAD;
                HumanState = HumanState.WALK;
                break;
            case HumanState.START:
                HumanState = HumanState.WALK;
                break;
            case HumanState.POINTBOY:
                //HumanState = HumanState.POINTBOY;
                HumanState = HumanState.WALK;
                break;
            case HumanState.POINTGIRL:
                //HumanState = HumanState.POINTGIRL;
                HumanState = HumanState.WALK;
                break;
            default:
                break;
        }
    }
}
