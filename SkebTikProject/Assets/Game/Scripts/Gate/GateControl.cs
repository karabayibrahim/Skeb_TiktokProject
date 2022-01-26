using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControl : MonoBehaviour
{
    public GameObject QuestionBox;
    void Start()
    {
        if (GameManager.Instance.LevelIndex==1)
        {
            QuestionBox.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
