using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Male : Human
{
    public GameObject MyHips;
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
            case HumanState.DRESSUP:
                transform.DOLocalMoveZ(4, 0.01f);
                break;
            case HumanState.HUGHER:
                transform.DOLocalMoveZ(1.25f, 0.01f);
                break;
            default:
                break;
        }
    }


}
