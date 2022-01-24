using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject PhonePanel;
    public Image BarMove;
    public GameObject Bar;
    private float distance;
    private float startAmount;
    private float amount;
    private bool finishBool = false;
    // Start is called before the first frame update
    void Start()
    {
        startAmount = Vector3.Distance(GameManager.Instance.CurrentLevel.FinishObject.gameObject.transform.position, GameManager.Instance.CurrentLevel.PlayerController.transform.position);
        Finish.FinishAction += FinishStatus;
    }

    private void OnDisable()
    {
        Finish.FinishAction -= FinishStatus;
    }
    // Update is called once per frame
    void Update()
    {
        BarMoveMove();
    }

    private void BarMoveMove()
    {
        if (!finishBool)
        {
            distance = Vector3.Distance(GameManager.Instance.CurrentLevel.FinishObject.gameObject.transform.position, GameManager.Instance.CurrentLevel.PlayerController.transform.position);
            amount = startAmount - distance;
            BarMove.fillAmount = amount / startAmount;
        }
    }

    private void FinishStatus()
    {
        Bar.SetActive(false);
        finishBool = true;
        BarMove.fillAmount = 1f;
    }
}
