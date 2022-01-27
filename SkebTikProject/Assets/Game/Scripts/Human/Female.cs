using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Female : Human
{
    public bool Fake = false;
    public TShirt Shirt;
    [Header("Level3")]

    public Howel Howel;
    public GameObject Short;

    //public GameObject MySpine;
    [Header("Level4")]
    public GameObject Bed;



    private Tween TakeOfTween;
    // Start is called before the first frame update
    private void Awake()
    {
        //_tempState = HumanState.START;
        //HumanState= HumanState.START;
        AssigmentComponent();
        //DontDestroyOnLoad(this);
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
        ClothesControl(GameManager.Instance.LevelIndex);
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
                transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                transform.DOLocalMove(new Vector3(-1.5f, 0, 0f), 0.5f);
                //MySpine.transform.DOLocalRotate(new Vector3(0, 0f, 0), 0.5f);
                break;
            case HumanState.WALK:
                transform.DOLocalMove(new Vector3(-1.5f, 0, 0f), 0.5f);
                transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                break;
            case HumanState.GETAHEAD:
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                transform.DOLocalMove(new Vector3(1.5f,0,7f),0.5f);
                //MySpine.transform.DOLocalRotate(new Vector3(0, 0f, 0), 0.5f);
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
                //MySpine.transform.DOLocalRotate(new Vector3(0, 45f, 0), 0.5f);
                break;
            case HumanState.HUGWALK:
                transform.DOLocalMove(new Vector3(1.5f, 0.78f, 6.2f), 0.5f);
                break;
            case HumanState.UNROLLTOWEL:
                Howel.RightHip.transform.DOLocalRotate(new Vector3(0,0,0),0.5f);
                Howel.RightChild.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
                Howel.LeftHip.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
                Howel.LeftChild.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
                transform.DOLocalMove(new Vector3(1.5f, 0, 7f), 0.5f);
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                break;
            case HumanState.IDLEGETAHEAD:
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                transform.DOLocalMove(new Vector3(1.5f, 0, 7f), 0.5f);
                break;
            case HumanState.IDLETAKEOFF:
                transform.DOLocalMove(new Vector3(1.5f, 0, 7f), 0.5f);
                transform.DORotate(new Vector3(0, 180f, 0), 0.01f);
                break;
            case HumanState.IDLEUNROLLTOWELL:
                transform.DOLocalMove(new Vector3(1.5f, 0, 7f), 0.5f);
                transform.DORotate(new Vector3(0, 180f, 0), 0.01f);
                break;
            case HumanState.IDLEHUG:
                transform.DOLocalMove(new Vector3(1.5f, 0.78f, 6.2f), 0.5f);
                break;
            case HumanState.IDLESLAP:
                transform.DOLocalMove(new Vector3(1.5f, 0, 5f), 0.5f);
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                break;
            case HumanState.CLOSETOWEL:
                transform.DORotate(new Vector3(0, 0, 0), 0.1f);
                transform.DOLocalMove(new Vector3(-1.5f, 0, 0f), 0.5f);
                Howel.RightHip.transform.DOLocalRotate(new Vector3(0, 0, Howel.RightZ), 0.5f);
                Howel.RightChild.transform.DOLocalRotate(new Vector3(0, 0, Howel.RightChildZ), 0.5f);
                Howel.LeftHip.transform.DOLocalRotate(new Vector3(0, 0, Howel.LeftZ), 0.5f);
                Howel.LeftChild.transform.DOLocalRotate(new Vector3(0, 0, Howel.LeftChildZ), 0.5f);
                //RunAnimation("Idle");
                break;
            case HumanState.ARGUING:
                transform.DOLocalMove(new Vector3(-3f, 0, 0f), 0.5f);
                //MySpine.transform.DOLocalRotate(new Vector3(0, 45f, 0), 0.5f);
                break;
            case HumanState.GETONBED:
                transform.DOLocalMove(new Vector3(-1.5f, 4.6f, 10f), 0.5f);
                break;
            case HumanState.GETYOURBED:
                transform.DOLocalMove(new Vector3(-1.5f, 4.6f, 10f), 0.5f);
                transform.DORotate(new Vector3(0, 45f, 0), 0.01f);
                break;
            case HumanState.REACHOVER:
                transform.DOLocalMove(new Vector3(5.5f, 5f, 11f), 0.5f);
                transform.DOLocalRotate(new Vector3(0, -45f, 0), 0.5f);
                break;
            case HumanState.ELBOWYOUR:
                transform.DOLocalMove(new Vector3(5.5f, 5f, 11f), 0.5f);
                transform.DOLocalRotate(new Vector3(0, -45f, 0), 0.5f);
                break;
            case HumanState.CHEATWITH:
                RunAnimation("Walk");
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
        HumanState = _tempIdleState;
        GetComponent<Animator>().enabled =false;
        //gameObject.SetActive(false);
    }

    private void ClothesControl(int _levelIndex)
    {
        switch (_levelIndex)
        {
            case 2:
                Shirt.gameObject.SetActive(false);
                Howel.gameObject.SetActive(true);
                Short.SetActive(false);
                break;
            case 3:
                Bed.SetActive(true);
                Howel.gameObject.SetActive(false);
                Shirt.gameObject.SetActive(true);
                Short.SetActive(true);
                break;
            default:
                Shirt.gameObject.SetActive(true);
                Howel.gameObject.SetActive(false);
                Short.SetActive(true);
                Bed.SetActive(false);
                break;
        }
    }
}
