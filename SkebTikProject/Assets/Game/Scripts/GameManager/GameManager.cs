using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using System;
public class GameManager : MonoSingleton<GameManager>
{
    private GameState _gamaState;
    private int _levelIndex;
    private string _playerLevelIndexKey = "PlayerLevelIndex";

    public Cameraman Cameraman;
    public DataParticles DataParticles;
    public Level CurrentLevel;
    public UIManager UIManager;
    public static Action GateTriggerAction;
    public static Action GameStartAction;
    public static Action GameAllEndAction;
    // Start is called before the first frame update

    public GameState GameState
    {
        get
        {
            return _gamaState;
        }
        set
        {
            if (GameState == value)
            {
                return;
            }
            _gamaState = value;
        }
    }

    public int LevelIndex
    {
        get
        {
            return _levelIndex;
        }
        set
        {
            if (LevelIndex==value)
            {
                return;
            }
            _levelIndex = value;
            OnLevelIndexChanghed();
        }

    }

    private void OnLevelIndexChanghed()
    {
        PlayerPrefs.SetInt(_playerLevelIndexKey, LevelIndex);
        //Debug.Log("Kayýt"+PlayerPrefs.GetInt(_playerLevelIndexKey));
    }

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        LevelIndex = PlayerPrefs.GetInt(_playerLevelIndexKey);
        Debug.Log(LevelIndex);
        GameState = GameState.START;
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void GameStartStatus()
    {
        if (GameState == GameState.START)
        {
            GameStartAction?.Invoke();
        }
        GameState = GameState.PLAY;
    }
}
