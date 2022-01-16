using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Male : Human
{
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
            default:
                break;
        }
    }


}
