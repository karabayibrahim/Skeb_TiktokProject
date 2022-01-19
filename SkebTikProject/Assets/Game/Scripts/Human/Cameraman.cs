using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using System;
public class Cameraman : Human
{
    private int _targetGateIndex = 0;

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
        if (Input.GetMouseButton(0))
        {
            //Debug.Log(Vector3.Distance(transform.position, GameManager.Instance.GatesSystem.Gates[TargetGateIndex].transform.position));
            transform.Translate(0, 0, GameManager.Instance.PlayerController.MoveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, GameManager.Instance.GatesSystem.Gates[TargetGateIndex].transform.position) <= 50&&!XMoveControl)
            {
                XMoveAction?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ICollectCameraman>()!=null)
        {
            other.gameObject.GetComponent<ICollectCameraman>().DoCollectCameraman();
        }
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

    private void CameramanMove()
    {
        //Agent.enabled = true;
        if (Vector3.Distance(transform.position,GameManager.Instance.GatesSystem.Gates[TargetGateIndex].transform.position)<=5)
        {
            //transform.position = new Vector3(Mathf.Lerp(transform.position.x, GameManager.Instance.GatesSystem.Gates[TargetGateIndex].transform.position.x, Time.deltaTime * 50f), transform.position.y, transform.position.z);
        }
        WalkStatus();
        //Agent.SetDestination(GameManager.Instance.Target.position);
        //gameObject.transform.rotation =new Quaternion(0, 180f, 0,0);
    }

    private void IdleOverride()
    {
        IdleStatus();
        //gameObject.transform.rotation = Quaternion.Euler(0, 180f, 0);
        //Agent.enabled = false;
    }

    private void XMove()
    {
        XMoveControl = true;
        transform.DOMoveX(GameManager.Instance.GatesSystem.Gates[TargetGateIndex].transform.position.x, 3f);
    }


}
