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
    public GameObject MainPhone;
    // Start is called before the first frame update
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

    public void YoyoFonk(float _positive,GameObject _obj)
    {
        _obj.transform.DOMoveX(_positive, 8f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }

    private void FinishStatus()
    {
        MainPhone.SetActive(true);
        CurrentLevel.LevelCam.enabled = false;
        CurrentLevel.SecondCam.enabled = true;
        //CurrentLevel.LevelCam.gameObject.GetComponent<Kamera>().YoyoT.Kill(true);
        //CurrentLevel.LevelCam.Follow = MainPhone.transform;
        //CurrentLevel.LevelCam.LookAt = MainPhone.transform;
        //CurrentLevel.LevelCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0, 0, 1.5f);
        //CurrentLevel.LevelCam.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset = new Vector3(0, 0, 0);
    }
}
