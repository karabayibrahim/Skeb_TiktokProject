using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gate : MonoBehaviour, ICollectable
{
    public Gate CoupleGate;
    public bool Trigged = false;
    public bool Rotete = false;
    public void DoCollect(int Index)
    {
        gameObject.GetComponent<Collider>().enabled = false;
        Trigged = true;
        CoupleGate.Trigged = true;
        if (gameObject.tag=="Positive")
        {
            var player = GameManager.Instance.CurrentLevel.PlayerController;
            GameManager.Instance.CurrentLevel.VideoPlayerController.VideoHumanState.Add(player.Male.HumanState = GameManager.Instance.CurrentLevel.DataHumanState.HumanStates[Index]);
            player.Male.HumanState = GameManager.Instance.CurrentLevel.DataHumanState.HumanStates[Index];
            player.Female.HumanState = GameManager.Instance.CurrentLevel.DataHumanState.HumanStates[Index];
            player.GateIndex++;
        }
        else
        {
            var player = GameManager.Instance.CurrentLevel.PlayerController;
            GameManager.Instance.CurrentLevel.VideoPlayerController.VideoHumanState.Add(player.Male.HumanState = GameManager.Instance.CurrentLevel.DataHumanState.HumanStatesNegative[Index]);
            player.Male.HumanState = GameManager.Instance.CurrentLevel.DataHumanState.HumanStatesNegative[Index];
            player.Female.HumanState = GameManager.Instance.CurrentLevel.DataHumanState.HumanStatesNegative[Index];
            player.GateIndex++;
        }
        GameManager.GateTriggerAction?.Invoke();
    }

    public void DoCollectNotIndex()
    {
        
    }

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

    private void FinishStatus()
    {
        gameObject.SetActive(false);
    }
}
