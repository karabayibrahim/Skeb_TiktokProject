using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Female : Human
{
    public TShirt Shirt;
    public bool Fake = false;
    public HumanState mysa;

    private Tween TakeOfTween;
    // Start is called before the first frame update
    private void Awake()
    {
        //_tempState = HumanState.START;
        //HumanState= HumanState.START;
        AssigmentComponent();
        DontDestroyOnLoad(this);
    }

    public void SlapEvent()
    {
        GameManager.Instance.CurrentLevel.PlayerController.Male.RunAnimation("SlapYour");
        GameManager.Instance.CurrentLevel.VideoPlayerController.Male.RunAnimation("SlapYour");
    }


    void Start()
    {
        if (!Fake)
        {
            GameManager.GameStartAction += StartStatusSub;
            StartStatus(9.5f, -0.63f, 0, -90f, "Start", 0.001f);
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
        mysa = HumanState;
    }
    public override void AnimPositon()
    {
        switch (HumanState)
        {
            case HumanState.IDLE:
                transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                transform.DOLocalMove(new Vector3(-1.5f, 0, 0f), 0.5f);
                break;
            case HumanState.WALK:
                break;
            case HumanState.GETAHEAD:
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                transform.DOLocalMove(new Vector3(1.5f,0,7f),0.5f);
                break;
            case HumanState.TAKEOFF:
                TakeOfTween=Shirt.MyMoveObject.transform.DOLocalMove(new Vector3(0,-0.15f,0.9f),10f);
                transform.DOLocalMove(new Vector3(1.5f, 0, 7f), 0.5f);
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                break;
            case HumanState.DRESSUP:
                TakeOfTween.Kill();
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                Shirt.MyMoveObject.transform.DOLocalMove(new Vector3(0, -0.18f, -0.4f), 1.8f);
                transform.DOLocalMove(new Vector3(1.5f, 0, 7f), 0.5f);
                break;
            case HumanState.SLAPYOUR:
                transform.DOLocalMove(new Vector3(1.5f, 0, 5f), 0.5f);
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                break;
            case HumanState.HUGHER:
                transform.DORotate(new Vector3(0, 180f, 0), 0.01f);
                transform.DOLocalMove(new Vector3(1.5f, 0, 7f), 0.5f);
                //gameObject.transform.SetParent(GameManager.Instance.CurrentLevel.PlayerController.Male.MyHips.transform);
                break;
            case HumanState.POINTBOY:
                transform.DOLocalMove(new Vector3(-3f, 0, 0f), 0.5f);
                transform.DORotate(new Vector3(0, 45f, 0), 0.5f);
                break;
            case HumanState.HUGWALK:
                transform.DOLocalMove(new Vector3(1.5f, 0.78f, 6.2f), 0.5f);
                break;
            case HumanState.IDLEGETAHEAD:
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                transform.DOLocalMove(new Vector3(1.5f, 0, 7f), 0.5f);
                break;
            case HumanState.IDLETAKEOFF:
                transform.DOLocalMove(new Vector3(1.5f, 0, 7f), 0.5f);
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                break;
            case HumanState.IDLEHUG:
                transform.DOLocalMove(new Vector3(1.5f, 0.78f, 6.2f), 0.5f);
                break;
            case HumanState.IDLESLAP:
                transform.DOLocalMove(new Vector3(1.5f, 0, 5f), 0.5f);
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                break;
            default:
                break;
        }
    }

    private void StartStatus(float x, float y, float z, float yRot, string anim,float duration)
    {
        GetComponent<Animator>().CrossFade(anim, 0.01f);
        transform.DOLocalMove(new Vector3(x, y, z), duration);
        transform.DOLocalRotate(new Vector3(0, yRot, 0), duration);
    }
    private void StartStatusSub()
    {
        StartStatus(-1.5f, 0, 0, 0, "Walk",0.5f);
    }

    private void FinishStatus()
    {
        //_tempState = HumanState.IDLE;
        //HumanState = HumanState.IDLE;
        GetComponent<Animator>().enabled = true;
        //gameObject.SetActive(false);
    }
}
