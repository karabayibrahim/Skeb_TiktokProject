using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class Kamera : MonoBehaviour
{
    //float offsetX = 0;
    // Start is called before the first frame update
    void Start()
    {
        YoyoKamera(45);
    }

    private void YoyoKamera(float _positive)
    {
        DOTween.To(() => gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x, x => gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x = x, _positive, 8f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }
    



}
