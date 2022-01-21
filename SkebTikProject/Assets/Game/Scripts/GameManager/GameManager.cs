using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GameManager : MonoSingleton<GameManager>
{
    public PlayerController PlayerController;
    public Cameraman Cameraman;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YoyoFonk(float _positive,GameObject _obj)
    {
        _obj.transform.DOMoveX(_positive, 8f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }
}
