using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Male : Human
{
    public GameObject MyHips;
    public bool Fake = false;

    private void Awake()
    {
        AssigmentComponent();
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        if (!Fake)
        {
            GameManager.GameStartAction += StartStatusSub;
            StartStatus(9.5f, -0.19f, -5f, -90f, "Start", 0.001f);
        }
        Finish.FinishAction += FinishStatus;
    }

    private void OnDisable()
    {
        GameManager.GameStartAction -= StartStatusSub;
        Finish.FinishAction -= FinishStatus;
    }
    // Update is called once per frame
    void Update()
    {
    }

    public override void AnimPositon()
    {
        switch (HumanState)
        {
            case HumanState.IDLE:
                break;
            case HumanState.WALK:
                break;
            case HumanState.DRESSUP:
                transform.DOLocalMoveZ(4, 0.5f);
                break;
            case HumanState.HUGHER:
                transform.DOLocalMoveZ(1.25f, 0.5f);
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
        StartStatus(1.5f,0,0,0,"Walk",0.5f);
    }
    private void FinishStatus()
    {
        GetComponent<Animator>().enabled = false;
        //gameObject.SetActive(false);
    }

}
