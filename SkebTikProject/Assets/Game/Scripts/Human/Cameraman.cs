using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using System;
public class Cameraman : Human
{

    private Tween YoyoT;

    public bool XMoveControl = false;
    public static Action XMoveAction;
    public GameObject MySpine;
    public GameObject FakePhone;
    public bool YoyoBool = true;
    public int YoyoCount = 0;

    // Start is called before the first frame update


    void Start()
    {
        GameManager.GameStartAction += StartStatus;
        Finish.FinishAction += FinishStatus;
        GetComponent<Animator>().CrossFade("Start", 0.01f);
        
    }

    private void OnDisable()
    {
        PlayerController.WalkActon -= CameramanMove;
        PlayerController.IdleAction -= IdleOverride;
        GameManager.GameStartAction -= StartStatus;
        Finish.FinishAction -= FinishStatus;
        XMoveAction -= XMove;
    }

    // Update is called once per frame
    void Update()
    {
        var LookPoz = new Vector3(GameManager.Instance.CurrentLevel.PlayerController.Male.transform.position.x, transform.position.y, GameManager.Instance.CurrentLevel.PlayerController.Male.transform.position.z);
        //transform.LookAt(GameManager.Instance.CurrentLevel.PlayerController.Male.transform);
        transform.LookAt(LookPoz);
    }
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

    private void StartStatus()
    {
        if (YoyoBool)
        {
            GetComponent<Animator>().CrossFade("IdleLegRight", 0.05f);
        }
        else
        {
            GetComponent<Animator>().CrossFade("IdleLeg", 0.05f);
        }
        GetComponent<Animator>().CrossFade("Walk", 0.01f);
        GetComponent<Animator>().CrossFade("Idle", 0.01f);
        base.AssigmentComponent();
        PlayerController.WalkActon += CameramanMove;
        PlayerController.IdleAction += IdleOverride;
        XMoveAction += XMove;
        YoyoFonk(10, gameObject);
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
        YoyoT=_obj.transform.DOMoveX(_positive, 8f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo).OnStepComplete(LegControl);
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

    private void FinishStatus()
    {
        YoyoT.Kill();
        GetComponent<Animator>().enabled = false;
        FakePhone.gameObject.SetActive(false);
        this.enabled = false;
    }
}
