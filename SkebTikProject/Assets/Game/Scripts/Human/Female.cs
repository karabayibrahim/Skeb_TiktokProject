using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Female : Human
{
    public TShirt Shirt;
    // Start is called before the first frame update
    void Start()
    {
        base.AssigmentComponent();
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
            case HumanState.GETAHEAD:
                transform.DOLocalMove(new Vector3(1.5f,0,7f),0.01f);
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                break;
            case HumanState.TAKEOFF:
                Shirt.MyMoveObject.transform.DOLocalMove(new Vector3(0,-0.15f,0.9f),1.8f);
                transform.DOLocalMove(new Vector3(1.5f, 0, 7f), 0.01f);
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                break;
            case HumanState.DRESSUP:
                Shirt.MyMoveObject.transform.DOLocalMove(new Vector3(0, -0.18f, -0.4f), 1.8f);
                transform.DOLocalMove(new Vector3(1.5f, 0, 7f), 0.01f);
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                break;
            case HumanState.SLAPYOUR:
                transform.DOLocalMove(new Vector3(1.5f, 0, 5f), 0.01f);
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                break;
            case HumanState.HUGHER:
                transform.DOLocalMove(new Vector3(1.5f, 0, 7f), 0.01f);
                transform.DORotate(new Vector3(0, 180F, 0), 0.01f);
                break;
            default:
                break;
        }
    }
}
