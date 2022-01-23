using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DataHumanState", order = 1)]
public class DataHumanState : ScriptableObject
{
    public List<HumanState> HumanStates = new List<HumanState>();
    public List<HumanState> HumanStatesNegative = new List<HumanState>();
}
