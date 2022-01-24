using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DataTextState", order = 1)]
public class DataTextState : ScriptableObject
{
    public List<GameObject> Positive = new List<GameObject>();
    public List<GameObject> Negative = new List<GameObject>();
}
