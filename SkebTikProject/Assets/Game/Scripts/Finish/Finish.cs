using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finish : MonoBehaviour,ICollectable
{
    public static Action FinishAction;
    public void DoCollect(int Index)
    {
        
    }

    public void DoCollectNotIndex()
    {
        FinishAction?.Invoke();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
