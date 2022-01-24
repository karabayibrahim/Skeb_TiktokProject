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
    public GameObject MySpine;
    public bool YoyoBool = true;
    public int YoyoCount = 0;

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
        if (YoyoBool)
        {
            GetComponent<Animator>().CrossFade("IdleLegRight", 0.05f);
        }
        else
        {
            GetComponent<Animator>().CrossFade("IdleLeg", 0.05f);
        }
        base.AssigmentComponent();
        PlayerController.WalkActon += CameramanMove;
        PlayerController.IdleAction += IdleOverride;
        XMoveAction += XMove;
        YoyoFonk(10, gameObject);
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
        var LookPoz = new Vector3(GameManager.Instance.CurrentLevel.PlayerController.Male.transform.position.x, GameManager.Instance.CurrentLevel.PlayerController.Male.transform.position.y, GameManager.Instance.CurrentLevel.PlayerController.Male.transform.position.z);
        //transform.LookAt(GameManager.Instance.CurrentLevel.PlayerController.Male.transform);
        transform.LookAt(LookPoz);
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

    public void YoyoFonk(float _positive, GameObject _obj)
    {
        _obj.transform.DOMoveX(_positive, 8f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo).OnStepComplete(LegControl);
    }

    private void LegControl()
    {
        YoyoCount++;
        if (YoyoCount%2==0)
        {
            YoyoBool = true;
        }
        else
        {
            YoyoBool = false;
        }
        if (YoyoBool)
        {
            if (HumanState == HumanState.IDLE)
            {
                GetComponent<Animator>().CrossFade("IdleLegRight", 0.05f);
            }
        }
        else
        {
            if (HumanState==HumanState.IDLE)
            {
                GetComponent<Animator>().CrossFade("IdleLeg", 0.05f);
            }
        }
    }
}
