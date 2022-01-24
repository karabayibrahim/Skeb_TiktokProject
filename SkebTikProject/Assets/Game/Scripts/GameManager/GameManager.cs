using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class GameManager : MonoSingleton<GameManager>
{
    public Cameraman Cameraman;
    public Transform Target;
    public Level CurrentLevel;
    public UIManager UIManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    

    //private void FinishStatus()
    //{
        
    //    //CurrentLevel.LevelCam.gameObject.GetComponent<Kamera>().YoyoT.Kill(true);
    //    //CurrentLevel.LevelCam.Follow = MainPhone.transform;
    //    //CurrentLevel.LevelCam.LookAt = MainPhone.transform;
    //    //CurrentLevel.LevelCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0, 0, 1.5f);
    //    //CurrentLevel.LevelCam.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset = new Vector3(0, 0, 0);
    //}
}
