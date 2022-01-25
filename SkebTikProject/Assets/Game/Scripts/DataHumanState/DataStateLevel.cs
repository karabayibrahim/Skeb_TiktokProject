using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DataStateLevel", order = 1)]
public class DataStateLevel : ScriptableObject
{
    public List<DataHumanState> DataHumanStates = new List<DataHumanState>();
    public List<DataTextState> DataTextLevels = new List<DataTextState>();
    
}
