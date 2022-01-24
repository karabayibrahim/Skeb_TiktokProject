using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SecondKamera : MonoBehaviour
{
    public Tween YoyoT;
    private float Xpoz;
    void Start()
    {
        YoyoKamera(12);
    }

    private void Update()
    {
        gameObject.transform.position = new Vector3(Xpoz, transform.position.y,transform.position.z);
        var MyLookAt = new Vector3(GameManager.Instance.CurrentLevel.VideoPlayerController.Male.transform.position.x, GameManager.Instance.CurrentLevel.VideoPlayerController.Male.transform.position.y+5f, GameManager.Instance.CurrentLevel.VideoPlayerController.Male.transform.position.z);
        transform.LookAt(MyLookAt);
    }

    private void YoyoKamera(float _positive)
    {
        YoyoT = DOTween.To(() => Xpoz, x => Xpoz = x, _positive, 8f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }
}
