using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Male : Human
{
    public GameObject MySpine;
    public bool Fake = false;
    public HumanState mysa;
    private void Awake()
    {
        //_tempState = HumanState.START;
        //HumanState = HumanState.START;
        AssigmentComponent();
        //DontDestroyOnLoad(this);
    }
    void Start()
    {
        if (!Fake)
        {
            GameManager.GameStartAction += StartStatusSub;
            StartStatus(9.5f, -0.19f, -5f, -90f, "Start", 0.001f);
        }
        Finish.FinishAction += FinishStatus;
        BedControl(GameManager.Instance.LevelIndex);
    }

 

    private void OnDisable()
    {
        GameManager.GameStartAction -= StartStatusSub;
        Finish.FinishAction -= FinishStatus;
    }
    // Update is called once per frame
    void Update()
    {
        mysa = HumanState;
    }

    public override void AnimPositon()
    {
        switch (HumanState)
        {
            case HumanState.IDLE:
                transform.DOLocalMove(new Vector3(1.5f, 0, 0f), 0.5f);
                transform.DORotate(new Vector3(0, 0, 0), 0.5f);
                MySpine.transform.DOLocalRotate(new Vector3(0, 0f, 0), 0.5f);
                break;
            case HumanState.WALK:
                transform.DOLocalMove(new Vector3(1.5f, 0, 0f), 0.5f);
                transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                break;
            case HumanState.DRESSUP:
                transform.DOLocalMoveZ(4, 0.5f);
                break;
            case HumanState.HUGHER:
                transform.DOLocalMoveZ(1.25f, 0.5f);
                break;
            case HumanState.POINTGIRL:
                transform.DOLocalMove(new Vector3(3f, 0, 0f), 0.5f);
                MySpine.transform.DOLocalRotate(new Vector3(0, -45f, 0), 0.5f);
                break;
            case HumanState.TRIESTO:
                transform.DORotate(new Vector3(0, -90f, 0), 0.5f);
                break;
            case HumanState.CLOSETOWEL:
                transform.DOLocalMove(new Vector3(-1.5f, 0, -2f), 0.5f);
                break;
            case HumanState.JUMPON:
                transform.DOLocalMove(new Vector3(-1.5f, 0, -2f), 0.1f);
                break;
            case HumanState.ARGUING:
                transform.DOLocalMove(new Vector3(3f, 0, 0f), 0.5f);
                //MySpine.transform.DOLocalRotate(new Vector3(0, -45f, 0), 0.5f);
                break;
            case HumanState.BEDIDLE:
                transform.DOLocalMove(new Vector3(3f, 4.5f, 13f), 0.1f);
                transform.DOLocalRotate(new Vector3(0, -270f, 0), 0.1f);
                break;
            case HumanState.GETYOURBED:
                transform.DOLocalMove(new Vector3(3f, 4.5f, 13f), 0.1f);
                transform.DOLocalRotate(new Vector3(0, 0f, 0), 0.1f);
                break;
            case HumanState.REACHOVER:
                transform.DOLocalMove(new Vector3(3f, 4.5f, 13f), 0.1f);
                transform.DOLocalRotate(new Vector3(0, 0f, 0), 0.1f);
                break;
            case HumanState.ELBOWYOUR:
                transform.DOLocalMove(new Vector3(3f, 4.5f, 13f), 0.1f);
                transform.DOLocalRotate(new Vector3(0, 0f, 0), 0.1f);
                break;
            default:
                break;
        }
    }
    private void StartStatus(float x, float y, float z, float yRot, string anim, float duration)
    {
        GetComponent<Animator>().CrossFade(anim, 0.01f);
        transform.DOLocalMove(new Vector3(x, y, z), duration);
        transform.DOLocalRotate(new Vector3(0, yRot, 0), duration);
    }

    private void StartStatusSub()
    {
        if (GameManager.Instance.LevelIndex==3)
        {
            return;
        }
        StartStatus(1.5f,0,0,0,"Walk",0.5f);
    }
    private void FinishStatus()
    {
        //_tempState = HumanState.IDLE;
        //HumanState = HumanState.IDLE;
        GetComponent<Animator>().enabled = false;
        //gameObject.SetActive(false);
    }

    private void BedControl(int _index)
    {
        switch (_index)
        {
            case 3:
                _tempIdleState= HumanState.BEDIDLE;
                _tempState= HumanState.BEDIDLE;
                HumanState = HumanState.BEDIDLE;
                RunAnimation("BedIdle");
                break;
            default:
                break;
        }
    }

}
