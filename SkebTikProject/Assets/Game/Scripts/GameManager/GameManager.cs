using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using System;
public class GameManager : MonoSingleton<GameManager>
{
    private GameState _gamaState;

    public Cameraman Cameraman;
    public Transform Target;
    public Level CurrentLevel;
    public UIManager UIManager;
    public static Action GateTriggerAction;
    public static Action GameStartAction;
    // Start is called before the first frame update

    public GameState GameState
    {
        get
        {
            return _gamaState;
        }
        set
        {
            if (GameState==value)
            {
                return;
            }
            _gamaState = value;
        }
    }
    void Start()
    {
        GameState = GameState.START;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameState==GameState.START)
            {
                GameStartAction?.Invoke();
            }
            GameState = GameState.PLAY;
        }
    }
}
