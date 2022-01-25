using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Level : MonoBehaviour
{
    public DataStateLevel DataStateLevel;
    //public DataHumanState DataHumanState;
    //public DataTextState DataTextState;
    public PlayerController PlayerController;
    public CinemachineVirtualCamera LevelCam;
    public CinemachineVirtualCamera SecondCam;
    public VideoPlayerController VideoPlayerController;
    public GameObject MainPhone;
    public GameObject FinishObject;
    void Start()
    {
        Finish.FinishAction += FinishStatus;
    }

    private void OnDisable()
    {
        Finish.FinishAction -= FinishStatus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FinishStatus()
    {
        MainPhone.SetActive(true);
        LevelCam.enabled = false;
        SecondCam.enabled = true;
    }
}
