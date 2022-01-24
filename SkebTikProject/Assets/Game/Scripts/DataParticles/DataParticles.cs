using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DataParticles", order = 1)]
public class DataParticles : ScriptableObject
{
    public List<GameObject> Particles = new List<GameObject>();
}
