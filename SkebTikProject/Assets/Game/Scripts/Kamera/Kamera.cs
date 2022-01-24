using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using System;
public class Kamera : MonoBehaviour
{
    //float offsetX = 0;
    // Start is called before the first frame update
    public Tween YoyoT;
    void Start()
    {
        GameManager.GameStartAction += YoyoSub;
    }

    private void OnDisable()
    {
        GameManager.GameStartAction -= YoyoSub;
    }

    private void YoyoKamera(float _positive)
    {
        YoyoT=DOTween.To(() => gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x, x => gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x = x, _positive, 8f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }
    
    private void YoyoSub()
    {
        YoyoKamera(12);
    }



}
