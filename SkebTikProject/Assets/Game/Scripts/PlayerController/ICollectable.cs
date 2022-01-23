using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    void DoCollect(int Index);
    void DoCollectNotIndex();
}
