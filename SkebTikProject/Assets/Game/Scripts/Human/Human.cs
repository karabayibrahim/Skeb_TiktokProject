using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Human : MonoBehaviour
{
    private HumanState _humanState;
    public HumanState _tempState;
    public HumanState _tempIdleState;
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
            if (HumanState == value)
            {
                return;
            }
            _humanState = value;
            if (GameManager.Instance.CurrentLevel.PlayerController.Male != null && GameManager.Instance.CurrentLevel.PlayerController.Female != null)
            {
                OnStateChanged();
            }
            if (GameManager.Instance.CurrentLevel.PlayerController.Male.gameObject != null && GameManager.Instance.CurrentLevel.PlayerController.Female.gameObject != null)
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
                _tempState = HumanState.IDLE;
                _tempIdleState = HumanState.IDLE;
                RunAnimation("Idle");
                var Cameraman = GameManager.Instance.CurrentLevel.PlayerController.Cameraman;
                if (Cameraman != null)
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
                _tempState = HumanState.WALK;
                _tempIdleState = HumanState.WALK;
                RunAnimation("Walk");
                break;
            case HumanState.GETAHEAD:
                _tempState = HumanState.GETAHEAD;
                _tempIdleState = HumanState.GETAHEAD;
                RunAnimation("GetAhead");
                break;
            case HumanState.TAKEOFF:
                _tempState = HumanState.TAKEOFF;
                _tempIdleState = HumanState.TAKEOFF;
                RunAnimation("TakeOff");
                RunAnimation("GetAhead");
                break;
            case HumanState.DRESSUP:
                _tempState = HumanState.DRESSUP;
                _tempIdleState = HumanState.DRESSUP;
                RunAnimation("DressUp");
                RunAnimation("GetAhead");
                break;
            case HumanState.HUGHER:
                _tempState = HumanState.HUGHER;
                _tempIdleState = HumanState.HUGHER;
                RunAnimation("HugHer");
                break;
            case HumanState.SLAPYOUR:
                _tempState = HumanState.SLAPYOUR;
                _tempIdleState = HumanState.SLAPYOUR;
                if (gameObject.tag=="Female")
                {
                    RunAnimation("SlapYour");
                }
                RunAnimation("GetAhead");
                break;
            case HumanState.WALKKEEP:
                _tempState = HumanState.WALKKEEP;
                _tempIdleState = HumanState.WALKKEEP;
                RunAnimation("Walk");
                break;
            case HumanState.START:
                _tempState = HumanState.START;
                _tempIdleState = HumanState.WALKKEEP;
                RunAnimation("Start");
                break;
            case HumanState.HUGWALK:
                _tempState = HumanState.HUGWALK;
                _tempIdleState = HumanState.HUGWALK;
                RunAnimation("HugWalk");
                break;
            case HumanState.POINTBOY:
                _tempState = HumanState.POINTBOY;
                _tempIdleState = HumanState.POINTBOY;
                RunAnimation("PointBoy");
                //RunAnimation("Walk");
                break;
            case HumanState.POINTGIRL:
                _tempState = HumanState.POINTGIRL;
                _tempIdleState = HumanState.POINTGIRL;
                RunAnimation("PointGirl");
                //RunAnimation("Walk");
                break;
            case HumanState.IDLEHUG:
                _tempState = HumanState.IDLEHUG;
                _tempIdleState = HumanState.IDLEHUG;
                GameManager.Instance.CurrentLevel.PlayerController.Male.RunAnimation("Idle");
                GameManager.Instance.CurrentLevel.PlayerController.Female.RunAnimation("HugWalk");
                //RunAnimation("HugWalk");
                break;
            case HumanState.IDLEGETAHEAD:
                _tempState = HumanState.IDLEGETAHEAD;
                _tempIdleState = HumanState.IDLEGETAHEAD;
                RunAnimation("Idle");
                break;
            case HumanState.IDLETAKEOFF:
                _tempState = HumanState.IDLETAKEOFF;
                _tempIdleState = HumanState.IDLETAKEOFF;
                RunAnimation("Idle");
                break;
            case HumanState.IDLESLAP:
                _tempState = HumanState.IDLESLAP;
                _tempIdleState = HumanState.IDLESLAP;
                RunAnimation("Idle");
                break;
            default:
                //RunAnimation("Idle");
                break;
        }
    }

    void Start()
    {
        
    }

    private void OnEnable()
    {
        //DontDestroyOnLoad(this);
        GameManager.GameAllEndAction += FinishStatus;
        PlayerController.WalkActon += WalkStatus;
        PlayerController.IdleAction += IdleStatus;
        //HumanState = HumanState.START;
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

    public void RunAnimation(string _animName)
    {
        if (Anim != null)
        {
            Anim.CrossFade(_animName, 0.001f);
        }
    }

    internal void AssigmentComponent()
    {
        Anim = GetComponent<Animator>();
    }
    internal void WalkStatus()
    {
        //GameManager.Instance.CurrentLevel.PlayerController.Male.Anim.SetLayerWeight(1, 1);
        if (this!=null)
        {
            TempStateControl();
        }
        //switch (HumanState)
        //{
        //    case HumanState.START:
        //        //TempStateControl();
        //        break;
        //    case HumanState.IDLE:
        //        HumanState = HumanState.WALK;
        //        //TempStateControl();
        //        break;
        //    case HumanState.WALK:
        //        HumanState = HumanState.WALK;
        //        //TempStateControl();
        //        break;
        //    case HumanState.WALKKEEP:
        //        HumanState = HumanState.WALK;
        //        break;
        //    case HumanState.GETAHEAD:
        //        HumanState = HumanState.GETAHEAD;
        //        //TempStateControl();
        //        break;
        //    case HumanState.TAKEOFF:
        //        HumanState = HumanState.GETAHEAD;
        //        break;
        //    case HumanState.HUGHER:
        //        GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.WALK;
        //        GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.HUGHER;
        //        //GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.GETAHEAD;
        //        break;
        //    case HumanState.SLAPYOUR:
        //        HumanState = HumanState.WALK;
        //        //TempStateControl();
        //        break;
        //    case HumanState.DRESSUP:
        //        GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.WALK;
        //        GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.WALK;
        //        //HumanState = HumanState.GETAHEAD;
        //        break;
        //    case HumanState.POINTBOY:
        //        //TempStateControl();
        //        HumanState = HumanState.POINTBOY;
        //        break;
        //    case HumanState.POINTGIRL:
        //        //TempStateControl();
        //        HumanState = HumanState.POINTGIRL;
        //        break;
        //    case HumanState.HUGWALK:
        //        GameManager.Instance.CurrentLevel.PlayerController.Male.Anim.SetLayerWeight(1, 0);
        //        HumanState = HumanState.WALK;
        //        //TempStateControl();
        //        //TempStateControl();
        //        break;
        //    default:
        //        break;
        //}

    }
    internal void IdleStatus()
    {
        //GameManager.Instance.CurrentLevel.PlayerController.Male.Anim.SetLayerWeight(1,0);
        if (this!=null)
        {
            TempStateIdleControl();
        }
        Debug.Log(_tempState);
        //switch (HumanState)
        //{
        //    case HumanState.START:
        //        HumanState = HumanState.IDLE;
        //        //TempStateControl();
        //        break;
        //    case HumanState.IDLE:
        //        HumanState = HumanState.IDLE;
        //        //TempStateIdleControl();
        //        //TempStateControl();
        //        //manState = HumanState.IDLE;
        //        break;
        //    case HumanState.WALK:
        //        //TempStateControl();
        //        GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.IDLE;
        //        GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.IDLE;
        //        GameManager.Instance.CurrentLevel.PlayerController.Cameraman.GetComponent<Cameraman>().HumanState = HumanState.IDLE;
        //        //HumanState = HumanState.IDLE;
        //        break;
        //    case HumanState.GETAHEAD:
        //        HumanState = HumanState.IDLE;
        //        break;
        //    case HumanState.WALKKEEP:
        //        HumanState = HumanState.IDLE;
        //        break;
        //    case HumanState.SLAPYOUR:
        //        HumanState = HumanState.IDLE;
        //        break;
        //    case HumanState.TAKEOFF:
        //        //TempStateIdleControl();
        //        HumanState = HumanState.IDLE;
        //        //GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.IDLE;
        //        break;
        //    case HumanState.HUGHER:
        //        HumanState = HumanState.IDLE;
        //        //TempStateIdleControl();
        //        //HumanState = HumanState.IDLEHUG;
        //        break;
        //    case HumanState.DRESSUP:
        //        GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.IDLE;
        //        GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.IDLE;
        //        //HumanState = HumanState.IDLE;
        //        break;
        //    case HumanState.POINTBOY:
        //        //TempStateIdleControl();
        //        HumanState = HumanState.IDLE;
        //        break;
        //    case HumanState.POINTGIRL:
        //        //TempStateIdleControl();
        //        HumanState = HumanState.IDLE;
        //        break;
        //    case HumanState.HUGWALK:
        //        HumanState = HumanState.IDLE;
        //        //TempStateIdleControl();
        //        //HumanState = HumanState.IDLE;
        //        break;
        //    default:
        //        break;
        //}
    }

    private void TempStateControl()
    {
        switch (_tempState)
        {
            case HumanState.IDLE:
                HumanState = HumanState.WALK;
                //HumanState = HumanState.WALK;
                break;
            case HumanState.WALK:
                HumanState = HumanState.WALK;
                //HumanState = HumanState.WALK;
                //HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.GETAHEAD:
                HumanState = HumanState.GETAHEAD;
                //HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.SLAPYOUR:
                HumanState = HumanState.WALK;
                break;
            case HumanState.TAKEOFF:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.HUGHER:
                GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.HUGWALK;
                GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.HUGWALK;
                //HumanState = HumanState.HUGWALK;
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
                //GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.WALK;
                //GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.WALK;
                //GameManager.Instance.CurrentLevel.PlayerController.Cameraman.GetComponent<Cameraman>().HumanState = HumanState.WALK;
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
            case HumanState.HUGWALK:
                GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.HUGWALK;
                GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.WALK;
                break;
            case HumanState.IDLEGETAHEAD:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.IDLETAKEOFF:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.IDLEHUG:
                GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.HUGWALK;
                GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.WALK;
                break;
            case HumanState.IDLESLAP:
                HumanState = HumanState.GETAHEAD;
                break;
            default:
                break;
        }
    }
    private void TempStateIdleControl()
    {
        switch (_tempIdleState)
        {
            case HumanState.START:
                //GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.IDLE;
                //GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.IDLE;
                HumanState = HumanState.IDLE;
                break;
            case HumanState.IDLE:
                //GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.IDLE;
                //GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.IDLE;
                HumanState = HumanState.IDLE;
                break;
            case HumanState.WALK:
                //GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.IDLE;
                //GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.IDLE;
                HumanState = HumanState.IDLE;
                break;
            case HumanState.GETAHEAD:
                HumanState = HumanState.IDLEGETAHEAD;
                break;
            case HumanState.SLAPYOUR:
                HumanState = HumanState.IDLESLAP;
                break;
            case HumanState.TAKEOFF:
                HumanState = HumanState.IDLETAKEOFF;
                break;
            case HumanState.HUGHER:
                GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.IDLE;
                GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.HUGWALK;
                break;
            case HumanState.DRESSUP:
                break;
            case HumanState.WALKKEEP:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.HUGWALK:
                //HumanState = HumanState.IDLEHUG;
                GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.IDLEHUG;
                GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.IDLEHUG;
                break;
            case HumanState.POINTGIRL:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.POINTBOY:
                HumanState = HumanState.IDLE;
                break;
            default:
                //HumanState = HumanState.IDLE;
                break;
        }
    }

    private void FinishStatus()
    {
        //_tempIdleState = HumanState.START;
        //Destroy(this);
    }
}
