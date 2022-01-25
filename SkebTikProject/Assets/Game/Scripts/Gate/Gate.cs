using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gate : MonoBehaviour, ICollectable
{
    public Gate CoupleGate;
    public bool Trigged = false;
    public bool Rotete = false;
    public GameObject VisableObj;
    public void DoCollect(int Index)
    {
        gameObject.GetComponent<Collider>().enabled = false;
        Trigged = true;
        CoupleGate.Trigged = true;
        ParticleStatus();
        if (gameObject.tag=="Positive")
        {
            StartCoroutine(PositiveTimer(Index));
        }
        else
        {
            StartCoroutine(NegativeTimer(Index));
        }
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

    private void ParticleStatus()
    {
        var newParticle = Instantiate(GameManager.Instance.DataParticles.Particles[0], transform.position, Quaternion.identity,transform);
        newParticle.transform.localPosition = new Vector3(0, 0, 0);
        newParticle.transform.SetParent(null);
        VisableObj.SetActive(false);
        CoupleGate.VisableObj.SetActive(false);
        //Destroy(CoupleGate.gameObject);
        //Destroy(gameObject);
    }

    private IEnumerator PositiveTimer(int _index)
    {
        yield return new WaitForSeconds(0.3f);
        var player = GameManager.Instance.CurrentLevel.PlayerController;
        GameManager.Instance.CurrentLevel.VideoPlayerController.VideoHumanState.Add(player.Male.HumanState = GameManager.Instance.CurrentLevel.DataHumanState.HumanStates[_index]);
        player.Male.HumanState = GameManager.Instance.CurrentLevel.DataHumanState.HumanStates[_index];
        player.Female.HumanState = GameManager.Instance.CurrentLevel.DataHumanState.HumanStates[_index];
        player.GateIndex++;
        GameManager.GateTriggerAction?.Invoke();
    }

    private IEnumerator NegativeTimer(int _index)
    {
        yield return new WaitForSeconds(0.3f);
        var player = GameManager.Instance.CurrentLevel.PlayerController;
        GameManager.Instance.CurrentLevel.VideoPlayerController.VideoHumanState.Add(player.Male.HumanState = GameManager.Instance.CurrentLevel.DataHumanState.HumanStatesNegative[_index]);
        player.Male.HumanState = GameManager.Instance.CurrentLevel.DataHumanState.HumanStatesNegative[_index];
        player.Female.HumanState = GameManager.Instance.CurrentLevel.DataHumanState.HumanStatesNegative[_index];
        player.GateIndex++;
        GameManager.GateTriggerAction?.Invoke();
    }
}
