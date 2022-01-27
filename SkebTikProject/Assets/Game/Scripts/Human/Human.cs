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
    public bool IdleBlock = false;
    public bool WalkBlock = false;
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
                AvatarChange();
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
                //AvatarChange();
                _tempState = HumanState.WALK;
                _tempIdleState = HumanState.WALK;
                RunAnimation("Walk");
                break;
            case HumanState.GETAHEAD:
                AvatarChange();
                _tempState = HumanState.GETAHEAD;
                _tempIdleState = HumanState.GETAHEAD;
                Anim.SetBool("SpecialIdle", false);
                RunAnimation("GetAhead");
                break;
            case HumanState.TAKEOFF:
                AvatarChange();
                _tempState = HumanState.TAKEOFF;
                _tempIdleState = HumanState.TAKEOFF;
                RunAnimation("TakeOff");
                RunAnimation("GetAhead");
                break;
            case HumanState.UNROLLTOWEL:
                AvatarChange();
                _tempState = HumanState.UNROLLTOWEL;
                _tempIdleState = HumanState.UNROLLTOWEL;
                if (gameObject.tag=="Female")
                {
                    RunAnimation("UnrollTowel");
                }
                else
                {
                    RunAnimation("TakeOff");
                }
                RunAnimation("GetAhead");
                break;
            case HumanState.DRESSUP:
                AvatarChange();
                _tempState = HumanState.DRESSUP;
                _tempIdleState = HumanState.DRESSUP;
                RunAnimation("DressUp");
                RunAnimation("GetAhead");
                break;
            case HumanState.HUGHER:
                AvatarChange();
                _tempState = HumanState.HUGHER;
                _tempIdleState = HumanState.HUGHER;
                RunAnimation("HugHer");
                break;
            case HumanState.SLAPYOUR:
                AvatarChange();
                _tempState = HumanState.SLAPYOUR;
                _tempIdleState = HumanState.SLAPYOUR;
                if (gameObject.tag=="Female")
                {
                    RunAnimation("SlapYour");
                }
                RunAnimation("GetAhead");
                break;
            case HumanState.PUSHYOUR:
                AvatarChange();
                _tempState = HumanState.PUSHYOUR;
                _tempIdleState = HumanState.PUSHYOUR;
                if (gameObject.tag == "Female")
                {
                    RunAnimation("PushYour");
                }
                else
                {
                    RunAnimation("SlapYour");
                }
                //RunAnimation("Walk");
                break;
            case HumanState.ARGUING:
                AvatarChangeTemp();
                _tempState = HumanState.ARGUING;
                _tempIdleState = HumanState.ARGUING;
                RunAnimation("Arguing");
                break;
            case HumanState.WALKKEEP:
                AvatarChange();
                _tempState = HumanState.WALKKEEP;
                _tempIdleState = HumanState.WALKKEEP;
                RunAnimation("Walk");
                break;
            case HumanState.START:
                AvatarChange();
                _tempState = HumanState.START;
                _tempIdleState = HumanState.WALKKEEP;
                RunAnimation("Start");
                break;
            case HumanState.HUGWALK:
                AvatarChange();
                _tempState = HumanState.HUGWALK;
                _tempIdleState = HumanState.HUGWALK;
                RunAnimation("HugWalk");
                break;
            case HumanState.POINTBOY:
                AvatarChangeTemp();
                _tempState = HumanState.POINTBOY;
                _tempIdleState = HumanState.POINTBOY;
                RunAnimation("PointBoy");
                //RunAnimation("Walk");
                break;
            case HumanState.POINTGIRL:
                AvatarChangeTemp();
                _tempState = HumanState.POINTGIRL;
                _tempIdleState = HumanState.POINTGIRL;
                RunAnimation("PointGirl");
                break;
            case HumanState.JUMPON:
                AvatarChange();
                _tempState = HumanState.JUMPON;
                _tempIdleState = HumanState.JUMPON;
                RunAnimation("JumpOn");
                break;
            case HumanState.CLOSETOWEL:
                AvatarChange();
                _tempState = HumanState.CLOSETOWEL;
                _tempIdleState = HumanState.CLOSETOWEL;
                RunAnimation("CloseTowel");
                //RunAnimation("Walk");
                break;
            case HumanState.TRIESTO:
                AvatarChange();
                _tempState = HumanState.TRIESTO;
                _tempIdleState = HumanState.TRIESTO;
                RunAnimation("TriesTo");
                break;
            case HumanState.STARTDANCE:
                AvatarChange();
                _tempState = HumanState.STARTDANCE;
                _tempIdleState = HumanState.STARTDANCE;
                RunAnimation("StartDance");
                break;
            case HumanState.IDLEHUG:
                AvatarChange();
                _tempState = HumanState.IDLEHUG;
                _tempIdleState = HumanState.IDLEHUG;
                GameManager.Instance.CurrentLevel.PlayerController.Male.RunAnimation("Idle");
                GameManager.Instance.CurrentLevel.PlayerController.Female.RunAnimation("HugWalk");
                //RunAnimation("HugWalk");
                break;
            case HumanState.IDLEGETAHEAD:
                AvatarChange();
                _tempState = HumanState.IDLEGETAHEAD;
                _tempIdleState = HumanState.IDLEGETAHEAD;
                RunAnimation("Idle");
                break;
            case HumanState.IDLETAKEOFF:
                AvatarChange();
                _tempState = HumanState.IDLETAKEOFF;
                _tempIdleState = HumanState.IDLETAKEOFF;
                Anim.SetBool("SpecialIdle", true);
                RunAnimation("Idle");
                break;
            case HumanState.IDLEUNROLLTOWELL:
                AvatarChange();
                _tempState = HumanState.IDLEUNROLLTOWELL;
                _tempIdleState = HumanState.IDLEUNROLLTOWELL;
                Anim.SetBool("SpecialIdle", true);
                RunAnimation("Idle");
                break;
            case HumanState.IDLESLAP:
                AvatarChange();
                _tempState = HumanState.IDLESLAP;
                _tempIdleState = HumanState.IDLESLAP;
                RunAnimation("Idle");
                break;
            case HumanState.BEDIDLE:
                AvatarChange();
                _tempIdleState = HumanState.BEDIDLE;
                _tempState = HumanState.BEDIDLE;
                HumanState = HumanState.BEDIDLE;
                RunAnimation("BedIdle");
                break;
            case HumanState.GETONBED:
                AvatarChange();
                _tempIdleState = HumanState.GETONBED;
                _tempState = HumanState.GETONBED;
                RunAnimation("GetOn");
                break;
            case HumanState.GETYOURBED:
                AvatarChange();
                _tempIdleState = HumanState.GETYOURBED;
                _tempState = HumanState.GETYOURBED;
                RunAnimation("GetUp");
                break;
            case HumanState.REACHOVER:
                AvatarChange();
                _tempIdleState = HumanState.REACHOVER;
                _tempState = HumanState.REACHOVER;
                RunAnimation("ReachOver");
                break;
            case HumanState.ELBOWYOUR:
                AvatarChange();
                _tempIdleState = HumanState.ELBOWYOUR;
                _tempState = HumanState.ELBOWYOUR;
                RunAnimation("Elbow");
                break;
            case HumanState.CHEATWITH:
                AvatarChange();
                _tempIdleState = HumanState.CHEATWITH;
                _tempState = HumanState.CHEATWITH;
                RunAnimation("CheatWith");
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

    private void AvatarChangeTemp()
    {
        if (gameObject.tag=="Male")
        {
            gameObject.GetComponent<Animator>().avatar = GameManager.Instance.MaleTemp;
            RunAnimation("Walk");
        }
        else if (gameObject.tag == "Female")
        {
            gameObject.GetComponent<Animator>().avatar = GameManager.Instance.FemaleTemp;
            RunAnimation("Walk");
        }

    }

    public void AvatarChange()
    {
        if (gameObject.tag == "Male")
        {
            gameObject.GetComponent<Animator>().avatar = GameManager.Instance.MaleAsil;
        }
        else if(gameObject.tag == "Female")
        {
            gameObject.GetComponent<Animator>().avatar = GameManager.Instance.FemaleAsil;
        }
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
        if (this!=null&&!WalkBlock)
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
        if (this!=null&&!IdleBlock)
        {
            TempStateIdleControl();
        }
        //Debug.Log(_tempState);
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
            case HumanState.JUMPON:
                HumanState = HumanState.WALK;
                break;
            case HumanState.PUSHYOUR:
                HumanState = HumanState.WALK;
                break;
            case HumanState.TAKEOFF:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.BEDIDLE:
                HumanState = HumanState.BEDIDLE;
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
                HumanState = HumanState.WALK;
                break;
            case HumanState.ARGUING:
                HumanState = HumanState.WALK;
                break;
            case HumanState.CLOSETOWEL:
                HumanState = HumanState.WALK;
                break;
            case HumanState.TRIESTO:
                HumanState = HumanState.WALK;
                break;
            case HumanState.STARTDANCE:
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
            case HumanState.IDLEUNROLLTOWELL:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.IDLEHUG:
                GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.HUGWALK;
                GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.WALK;
                break;
            case HumanState.IDLESLAP:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.UNROLLTOWEL:
                HumanState = HumanState.GETAHEAD;
                break;
            case HumanState.GETONBED:
                HumanState = HumanState.GETONBED;
                break;
            case HumanState.REACHOVER:
                HumanState = HumanState.REACHOVER;
                break;
            case HumanState.GETYOURBED:
                HumanState = HumanState.WALK;
                break;
            case HumanState.ELBOWYOUR:
                HumanState = HumanState.ELBOWYOUR;
                break;
            case HumanState.CHEATWITH:
                if (gameObject.tag=="Female")
                {
                    HumanState = HumanState.WALK;
                }
                else
                {
                    HumanState = HumanState.CHEATWITH;
                }
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
            case HumanState.PUSHYOUR:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.JUMPON:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.TAKEOFF:
                HumanState = HumanState.IDLETAKEOFF;
                break;
            case HumanState.HUGHER:
                GameManager.Instance.CurrentLevel.PlayerController.Male.HumanState = HumanState.IDLE;
                GameManager.Instance.CurrentLevel.PlayerController.Female.HumanState = HumanState.HUGWALK;
                break;
            case HumanState.DRESSUP:
                HumanState = HumanState.IDLETAKEOFF;
                break;
            case HumanState.BEDIDLE:
                HumanState = HumanState.BEDIDLE;
                break;
            case HumanState.CHEATWITH:
                if (gameObject.tag == "Female")
                {
                    HumanState = HumanState.IDLE;
                }
                else
                {
                    HumanState = HumanState.CHEATWITH;
                }
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
            case HumanState.ARGUING:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.POINTBOY:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.CLOSETOWEL:
                HumanState = HumanState.CLOSETOWEL;
                break;
            case HumanState.TRIESTO:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.STARTDANCE:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.UNROLLTOWEL:
                HumanState = HumanState.IDLE;
                HumanState = HumanState.IDLEUNROLLTOWELL;
                break;
            case HumanState.GETONBED:
                HumanState = HumanState.GETONBED;
                break;
            case HumanState.REACHOVER:
                HumanState = HumanState.REACHOVER;
                break;
            case HumanState.GETYOURBED:
                HumanState = HumanState.IDLE;
                break;
            case HumanState.ELBOWYOUR:
                HumanState = HumanState.ELBOWYOUR;
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
